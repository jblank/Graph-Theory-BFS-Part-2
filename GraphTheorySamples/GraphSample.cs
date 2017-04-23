using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheorySamples
{
    /// <summary>
    /// Class for showing examples of using a breadth-first search over a graph
    /// </summary>
    public static class BFSGraphSample
    {
        /// <summary>
        /// Calculates number of hops from source city ID to destination city ID by using BFS.
        /// For the purposes of this demo, the assumption is that cities are sequentially numbered starting at 1.
        /// </summary>
        /// <param name="startingCityId">Id for starting city</param>
        /// <param name="endingCityId">Id for ending city</param>
        /// <param name="routes">List of routes to populate in graph</param>
        /// <param name="cities">List of cities to use for graph</param>
        /// <returns></returns>
        public static Tuple<int, double> GetHopsFromSourceToDestination(int startingCityId, int endingCityId, List<Route> routes, List<CityNode> cities, bool isDirectedGraph)
        {
            // Initialize Graph
            var graph = InitializeNetworkGraph(cities.Count, routes, isDirectedGraph);
            var nodeState = new NodeStatus[cities.Count + 1];
            var nodeFlightCount = new int[cities.Count + 1];
            var nodeDistance = new double[cities.Count + 1];

            // Breadth-first search (BFS) find the hops to each city
            var queue = new Queue<int>();
            var startNode = startingCityId;
            queue.Enqueue(startNode);

            do
            {
                var node = queue.Dequeue();
                for (int i = 1; i <= cities.Count; i++)
                {
                    if (graph[node, i] > 0 && nodeState[i] == NodeStatus.Unvisited)
                    {
                        queue.Enqueue(i);
                        nodeState[i] = NodeStatus.Visited;
                        nodeFlightCount[i] = nodeFlightCount[node] + 1;
                        nodeDistance[i] = nodeDistance[node] + graph[node, i];
                    }
                }
                nodeState[node] = NodeStatus.Completed;
            } while (queue.Any());

            return new Tuple<int, double>(nodeFlightCount[endingCityId], nodeDistance[endingCityId]);
        }

        /// <summary>
        /// Initializes a graph based on city count an a list of routes
        /// </summary>
        /// <param name="cityCount">Count of cities in graph</param>
        /// <param name="routes">List of routes to populate in graph</param>
        /// <returns>A graph of the network</returns>
        public static double[,] InitializeNetworkGraph(int cityCount, List<Route> routes, bool isDirectedGraph)
        {
            var networkGraph = new double[cityCount + 1, cityCount + 1];
            foreach (var route in routes)
            {
                networkGraph[route.StartingCityId, route.EndingCityId] = route.Distance;
                if (!isDirectedGraph)
                    networkGraph[route.EndingCityId, route.StartingCityId] = route.Distance;
            }
            return networkGraph;
        }
    }
}
