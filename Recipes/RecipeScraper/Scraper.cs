using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RecipeScraper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace RecipeScraper
{
    class Scraper
    {
        public static Recipe GetRecipe(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var respson = request.GetResponse())
            {

                var webRequest = new HtmlWeb();
                var htmlDocument = webRequest.Load(url);

                var recipeData = GetRecipeData(htmlDocument);

                return CreateRecipe(recipeData);
            }
        }

        private const string _recipeElementId = "__NEXT_DATA__";
        private const string _recipeJsonPath = "props.pageProps.structuredData[?(@['\x40type']=='Recipe')]";

        private static readonly JsonSerializer _serializer;
        static Scraper()
        {
            _serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        private static JObject GetRecipeData(HtmlDocument htmlDocument)
        {
            var htmlElement = htmlDocument.GetElementbyId(_recipeElementId).InnerHtml;
            var structuredData = JsonConvert.DeserializeObject<JObject>(htmlElement);

            return structuredData.SelectToken(_recipeJsonPath) as JObject;

        }

        private static Recipe CreateRecipe(JObject recipeData)
        {
            var recipe = new Recipe;

            var dto = recipeData.ToObject<RecipeDto>(_serializer);


            recipe.Name = (string)recipeData["name"].ToObject(typeof(string));
            recipe.Description = recipeData["description"].ToObject<string>();
            recipe.Image = recipeData["image"].ToObject<string>();

            recipe.Ingredient = new List<Ingredient>();
            foreach (var ingredient in recipeData["recipeIngredient"] as JArray)
            {

                var ingredientData = ((string)ingredient).Split(' ');
                var amountData = ((string)ingredient).Split(' ')[0];

                Ingredient ingredientToAdd;

                if (double.TryParse(amountData, out var amount))
                {
                    var name = ingredientData.Skip(2);

                    ingredientToAdd = new Ingredient
                    {
                        Amount = amount,
                        Unit = ingredientData[1],
                        Name = string.Join(" ", name)
                    };

                    recipe.Ingredient.Add(ingredientToAdd);
                }
                else
                {
                    ingredientToAdd = new Ingredient { Name = (string)ingredient };
                }
                recipe.Ingredient.Add(ingredientToAdd);

            }

            recipe.Step = new List<Step>();

            foreach (var instruction in recipeData["recipeInstructions"] as JArray)
            {
                var stripHtml = new Regex("<[^>]*(>|$)");
                var instructionpHtml = (string)instruction["text"];
                var instructionTxt = stripHtml.Replace(instructionpHtml, string.Empty);

                var stepToAddd = new Step
                {
                    Text = instructionTxt.Replace("\n", " ")
                };

                recipe.Step.Add(stepToAddd);
            }

            list.Add(recipe);

            return recipe;
        }

        private static Ingredient MapIngredient (string ingredientText)
        {

        }
    }
}
