using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace RecipeScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Recipe>();
            try
            {
                using (var b = new MemoryStream())
                {
                    try
                    {
                        var recepie = Scraper.GetRecipe("https://www.koket.se/smorstekt-torskrygg-med-pestoslungad-blomkal-och-sparris");
                        list.Add(recipe);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }

                try
                {
                    var r = (HttpWebRequest)WebRequest.Create(@"https://www.koket.se/vegoburgare-med-tryffelmajonnas");
                    using (var rr = r.GetResponse())
                    {
                        var tmp = new Recipe();
                        var htd = new HtmlDocument();
                        using (var c = rr.GetResponseStream())
                        {
                            using (var tmp2 = new MemoryStream())
                            {
                                c.CopyTo(tmp2);
                                tmp2.Seek(0, SeekOrigin.Begin);
                                htd.Load(tmp2);
                                var d = JsonConvert.DeserializeObject<JObject>(htd.GetElementbyId("__NEXT_DATA__").InnerHtml)
                                                                .SelectToken("props.pageProps.structuredData[?(@['\x40type']=='Recipe')]") as JObject;
                                tmp.Name = (string)d["name"].ToObject(typeof(string));
                                tmp.Description = (string)d["description"].ToObject(typeof(string));
                                tmp.Image = (string)d["image"].ToObject(typeof(string));
                                tmp.Igredient = new List<Ingredient>();
                                foreach (var tm3p in d["recipeIngredient"] as JArray)
                                {
                                    if (double.TryParse(((string)tm3p).Split(' ')[0], out var a))
                                    {
                                        var n = ((string)tm3p).Split(' ').Skip(2);
                                        tmp.Igredient.Add(new Ingredient { Amount = a, Unit = ((string)tm3p).Split(' ')[1], Name = string.Join(" ", n) });
                                    }
                                    else
                                    {
                                        tmp.Igredient.Add(new Ingredient { Name = (string)tm3p });
                                    }
                                }
                                tmp.Step = new List<Step>();
                                foreach (var t4mp in d["recipeInstructions"] as JArray)
                                    tmp.Step.Add(new Step { Tx = new Regex("<[^>]*(>|$)").Replace((string)t4mp["text"], string.Empty).Replace("\n", " ") });
                            }
                            list.Add(tmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                try
                {
                    var r = (HttpWebRequest)WebRequest.Create(@"https://www.koket.se/smakrik-o-lrisotto-med-vitlo-ksrostad-tomat-citronsparris-och-het-chorizo");
                    using (var rr = r.GetResponse())
                    {
                        var tmp = new Recipe();
                        var htd = new HtmlDocument();
                        using (var c = rr.GetResponseStream())
                        {
                            using (var tmp2 = new MemoryStream())
                            {
                                c.CopyTo(tmp2);
                                tmp2.Seek(0, SeekOrigin.Begin);
                                htd.Load(tmp2);
                                var d = JsonConvert.DeserializeObject<JObject>(htd.GetElementbyId("__NEXT_DATA__").InnerHtml)
                                .SelectToken("props.pageProps.structuredData[?(@['\x40type']=='Recipe')]") as JObject;
                                tmp.Name = (string)d["name"].ToObject(typeof(string));
                                tmp.Description = (string)d["description"].ToObject(typeof(string));
                                tmp.Image = (string)d["image"].ToObject(typeof(string));
                                tmp.Ingredient = new List<Ingredient>();
                                foreach (var tm3p in d["recipeIngredient"] as JArray)
                                {
                                    if (double.TryParse(((string)tm3p).Split(' ')[0], out var a))
                                    {
                                        var n = ((string)tm3p).Split(' ').Skip(2);
                                        tmp.Ingredient.Add(new Ingredient { Amount = a, Unit = ((string)tm3p).Split(' ')[1], Name = string.Join(" ", n) });
                                    }
                                    else
                                    {
                                        tmp.Ingredient.Add(new Ingredient { Name = (string)tm3p });
                                    }
                                }
                                tmp.Step = new List<Step>();
                                foreach (var t4mp in d["recipeInstructions"] as JArray)
                                    tmp.Step.Add(new Step { Tx = new Regex("<[^>]*(>|$)").Replace((string)t4mp["text"], string.Empty).Replace("\n", " ") });
                            }

                            list.Add(tmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                try
                {
                    var r = (HttpWebRequest)WebRequest.Create(@"https://www.koket.se/smorbakad-spetskal-med-krispig-kyckling-och-graddskum");
                    using (var rr = r.GetResponse())
                    {
                        var tmp = new Recipe();
                        var htd = new HtmlDocument();
                        using (var c = rr.GetResponseStream())
                        {
                            using (var tmp2 = new MemoryStream())
                            {
                                c.CopyTo(tmp2);
                                tmp2.Seek(0, SeekOrigin.Begin);
                                htd.Load(tmp2);
                                var d = JsonConvert.DeserializeObject<JObject>(htd.GetElementbyId("__NEXT_DATA__").InnerHtml)
                                .SelectToken("props.pageProps.structuredData[?(@['\x40type']=='Recipe')]") as JObject;
                                tmp.Name = (string)d["name"].ToObject(typeof(string));
                                tmp.Description = (string)d["description"].ToObject(typeof(string));
                                tmp.Image = (string)d["image"].ToObject(typeof(string));
                                tmp.Ingredient = new List<Ingredient>();
                                foreach (var tm3p in d["recipeIngredient"] as JArray)
                                {
                                    if (double.TryParse(((string)tm3p).Split(' ')[0], out var a))
                                    {
                                        var n = ((string)tm3p).Split(' ').Skip(2);
                                        tmp.Ingredient.Add(new Ingredient { Amount = a, Unit = ((string)tm3p).Split(' ')[1], Name = string.Join(" ", n) });
                                    }
                                    else
                                    {
                                        tmp.Ingredient.Add(new Ingredient { Name = (string)tm3p });
                                    }
                                }
                                tmp.Step = new List<Step>();
                                foreach (var t4mp in d["recipeInstructions"] as JArray)
                                    tmp.Step.Add(new Step { Tx = new Regex("<[^>]*(>|$)").Replace((string)t4mp["text"], string.Empty).Replace("\n", " ") });
                            }

                            list.Add(tmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            try
            {
                foreach(var recipe in list)
                {
                    Console.WriteLine($"Recept: {recipe.Name}");
                    Console.WriteLine("-------");
                    Console.WriteLine(recipe.Description.Trim());
                    Console.WriteLine("-------");
                    Console.WriteLine("Ingredienser:");


                    foreach (var ingredient in recipe.Ingredient)
                    {
                        if (ingredient.Amount == 0)
                            Console.WriteLine(ingredient.Name);
                        else
                            Console.WriteLine($"{ingredient.Amount} {ingredient.Unit} {ingredient.Name}");
                    }
                   
                    Console.WriteLine("-------");
                    Console.WriteLine("Steg:");

                    var stepCount = 1;

                    foreach (var step in recipe.Step )
                    {
                        Console.WriteLine($"{stepCount++}: {step.text}");
                    }
                  
                    Console.WriteLine();
                }
   
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredient { get; set; }
        public List<Step> Step { get; set; }
    }

    class Ingredient
    {
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
    }

    class Step
    {
        public string T1 { get; set; }
        public string Tx { get; set; }
    }
}
