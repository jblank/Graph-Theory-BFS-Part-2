﻿using FluentAssertions;
using GraphTheorySamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraphTheorySamplesTests
{
    [TestClass]
    public class GraphSampleTests
    {
        [TestMethod]
        public void when_initializing_graph_with_zero_cities()
        {
            var target = BFSGraphSample.InitializeNetworkGraph(0, new List<Route>(), false);

            target.Should().NotBeNull();
        }

        [TestMethod]
        public void when_initializing_graph_with_one_city_and_no_routes()
        {
            var target = BFSGraphSample.InitializeNetworkGraph(1, new List<Route>(), false);

            target.Should().NotBeNull();
        }

        [TestMethod]
        public void when_initializing_graph_with_multiple_cities_and_no_routes()
        {
            var routeList = new List<Route> {};
            var target = BFSGraphSample.InitializeNetworkGraph(3, routeList, false);

            target.Should().NotBeNull();
            target.Length.Should().Be(16); // Expecting a 4x4 array
        }

        [TestMethod]
        public void when_initializing_graph_with_multiple_cities_and_routes()
        {
            var routeList = new List<Route> { new Route(1, 2, 1), new Route(2, 3, 1) };
            var target = BFSGraphSample.InitializeNetworkGraph(3, routeList, false);

            target.Should().NotBeNull();
            target.Length.Should().Be(16);
            target[1, 2].Should().Be(1);
            target[1, 3].Should().Be(0);
            target[2, 3].Should().Be(1);
        }

        [TestMethod]
        public void when_running_sample_bfs_graph()
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

            var hops = BFSGraphSample.GetHopsFromSourceToDestination(1, 11, routeMap, cities, false);

            hops.Item1.Should().Be(3);
            hops.Item2.Should().Be(5279.87);
        }

        [TestMethod]
        public void when_running_sample_bfs_graph_directed()
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

            var hops = BFSGraphSample.GetHopsFromSourceToDestination(1, 11, routeMap, cities, true);

            hops.Item1.Should().Be(5);
            hops.Item2.Should().Be(4113.89);
        }
    }
}
