using System;
using System.Collections.Generic;

namespace GraphTheorySamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<CityNode>
            {
                new CityNode { CityId = 1 , Name = "Seattle"},
                new CityNode { CityId = 2 , Name = "Portland"},
                new CityNode { CityId = 3 , Name = "San Francisco"},
                new CityNode { CityId = 4 , Name = "Los Angeles"},
                new CityNode { CityId = 5 , Name = "Boise"},
                new CityNode { CityId = 6 , Name = "Salt Lake City"},
                new CityNode { CityId = 7 , Name = "Las Vegas"},
                new CityNode { CityId = 8 , Name = "Phoenix"},
                new CityNode { CityId = 9 , Name = "Denver"},
                new CityNode { CityId = 10 , Name = "Dallas"},
                new CityNode { CityId = 11 , Name = "Minneapolis"},
                new CityNode { CityId = 12 , Name = "Chicago"},
                new CityNode { CityId = 13 , Name = "Detroit"}
            };

            var routeMap = new List<Route>
            {
                new Route(1, 2),
                new Route(2, 3),
                new Route(3, 4),
                new Route(2, 5),
                new Route(2, 6),
                new Route(3, 6),
                new Route(3, 7),
                new Route(4, 7),
                new Route(4, 8),
                new Route(4, 9),
                new Route(8, 9),
                new Route(4, 10),
                new Route(9, 10),
                new Route(9, 11),
                new Route(1, 12),
                new Route(9, 12),
                new Route(12, 13)
            };

            var hops = BFSGraphSample.GetHopsFromSourceToDestination(1, 11, routeMap, cities, true);

            Console.WriteLine($"Minimum number of flights between cities: {hops} flights");
            Console.ReadLine();
        }
    }
}
