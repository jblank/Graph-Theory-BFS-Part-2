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
                new Route(1, 2, 208.02),
                new Route(2, 3, 886.34),
                new Route(3, 4, 542.16),
                new Route(2, 5, 552.6),
                new Route(2, 6, 1011.7),
                new Route(3, 6, 961.87),
                new Route(3, 7, 664.86),
                new Route(4, 7, 379.98),
                new Route(4, 8, 594.33),
                new Route(4, 9, 1385.07),
                new Route(8, 9, 968.49),
                new Route(4, 10, 1983.08),
                new Route(9, 10, 1032.05),
                new Route(9, 11, 1092.3),
                new Route(1, 12, 2761.62),
                new Route(9, 12, 1425.95),
                new Route(12, 13, 376.37)
            };

            Console.WriteLine("Breadth-First Search, specific graph type, 0 = undirected, 1 = directed");
            var useDirectedGraph = Console.ReadLine().Equals("1");

            var hops = BFSGraphSample.GetHopsFromSourceToDestination(1, 11, routeMap, cities, useDirectedGraph);

            Console.WriteLine($"Minimum number of flights between cities: {hops.Item1} flights ({hops.Item2} km)");
            Console.ReadLine();
        }
    }
}
