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
                new Route { StartingCityId = 1, EndingCityId = 2},
                new Route { StartingCityId = 2, EndingCityId = 3},
                new Route { StartingCityId = 3, EndingCityId = 4},
                new Route { StartingCityId = 2, EndingCityId = 5},
                new Route { StartingCityId = 2, EndingCityId = 6},
                new Route { StartingCityId = 3, EndingCityId = 6},
                new Route { StartingCityId = 3, EndingCityId = 7},
                new Route { StartingCityId = 4, EndingCityId = 7},
                new Route { StartingCityId = 4, EndingCityId = 8},
                new Route { StartingCityId = 4, EndingCityId = 9},
                new Route { StartingCityId = 8, EndingCityId = 9},
                new Route { StartingCityId = 4, EndingCityId = 10},
                new Route { StartingCityId = 9, EndingCityId = 10},
                new Route { StartingCityId = 9, EndingCityId = 11},
                new Route { StartingCityId = 1, EndingCityId = 12},
                new Route { StartingCityId = 9, EndingCityId = 12},
                new Route { StartingCityId = 12, EndingCityId = 13}
            };

            var hops = BFSGraphSample.GetHopsFromSourceToDestination(1, 11, routeMap, cities);

            Console.WriteLine($"Minimum number of flights between cities: {hops} flights");
            Console.ReadLine();
        }
    }
}
