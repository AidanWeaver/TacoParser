using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Threading;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            

            logger.LogInfo("Log initialized");

            
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogInfo("No lines found...");
            }
            else if (lines.Length == 1)
            {
                logger.LogInfo("Only 1 line found...");
            }
            
            logger.LogInfo($"Lines: {lines[0]}");

          
            var parser = new TacoParser();

          
            var locations = lines.Select(parser.Parse).ToArray();

            
            ITrackable firstTB = null;
            ITrackable lastTB = null; 
           
            double distBetween = 0;
            var geoA = new GeoCoordinate();
            var geoB = new GeoCoordinate();
            
            foreach (var locA in locations)
            {
                geoA.Latitude = locA.Location.Latitude;
                geoA.Longitude = locA.Location.Longitude;

                foreach (var locB in locations)
                {
                    geoB.Latitude = locB.Location.Longitude;
                    geoB.Longitude = locB.Location.Latitude;

                    if (geoA.GetDistanceTo(geoB) > distBetween)
                    {
                        distBetween = geoA.GetDistanceTo(geoB);
                        firstTB = locA;
                        lastTB= locB;


                    }
                }
            }

            Console.WriteLine(firstTB.Name);
            Console.WriteLine(lastTB.Name);
           

        }
    }
}
