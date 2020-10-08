using NGeoNames;
using NGeoNames.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace geocode
{
    class Program
    {
        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;

        static readonly (double Lat, double Lng) _gavlePosition;
        static readonly (double Lat, double Lng) _uppsalaPosition;
        static readonly IFormatProvider _formatProvider;


        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(".\\Resources\\SE.txt");
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);

            _gavlePosition = (60.674622, 17.141830);
            _uppsalaPosition = (59.858562, 17.638927);
            _formatProvider = CultureInfo.InvariantCulture;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Uppsala");
            Console.WriteLine("----------------");
            ListGavlePositions();

            Console.WriteLine("Gävle");
            Console.WriteLine("----------------");
            ListUppsalaPositions();

            Console.WriteLine("Distance");
            Console.WriteLine("----------------");
            
            ListUserPostion(args);

        }

        static void ListUserPostion(string[] args)
        {
            double lat = double.Parse(args[0]), _formatProvider);
            double lng = double.Parse(args[1]), _formatProvider);

            var nearestUser = _reverseGeoCodingService.RadialSearch(lat, lng, 10);

            foreach (var position in nearestUser)
            {
                Console.WriteLine($"{position.Name}");
            }
            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            // 2. Hitta alla platser inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            // 3. Lista x platser baserat på användarinmatning.
        }
        
        static void ListGavlePositions()
        {
            var nearestGavle = _reverseGeoCodingService.RadialSearch(_gavlePosition.Lat, _gavlePosition.Lng, 10)
                                                                .ToList();
            var earestGavle = nearestGavle.OrderBy(p => p.Name);

            foreach (var position in earestGavle)
            {
                Console.WriteLine($"{position.Name}, lat {position.Latitude}, lng {position.Longitude}");
            }
            Console.WriteLine();

        }

        static void ListUppsalaPositions()
        {
            var radius = 200 * 1000;
            var nearestUppsala = _reverseGeoCodingService.RadialSearch(_uppsalaPosition.Lat, _uppsalaPosition.Lng, radius, 50);

            nearestUppsala = nearestUppsala.OrderBy(x => x.DistanceTo(_uppsalaPosition.Lat, _uppsalaPosition.Lng));

            foreach (var position in nearestUppsala)
            {
                var uppsalaDistance = position.DistanceTo(_uppsalaPosition.Lat, _uppsalaPosition.Lng);

                Console.WriteLine($"{position.Name}, distance to Uppsala: {uppsalaDistance}");
            }
        }
    }
}
