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
        public static int GetHopsFromSourceToDestination(int startingCityId, int endingCityId, List<Route> routes, List<CityNode> cities, bool isDirectedGraph)
        {
            // Initialize Graph
            var graph = InitializeNetworkGraph(cities.Count, routes, isDirectedGraph);
            var nodeState = new NodeStatus[cities.Count + 1];
            var nodeDistance = new int[cities.Count + 1];

            // Breadth-first search (BFS) find the hops to each city
            var queue = new Queue<int>();
            var startNode = startingCityId;
            queue.Enqueue(startNode);

            do
            {
                var node = queue.Dequeue();
                for (int i = 1; i <= cities.Count; i++)
                {
                    if (graph[node, i] == 1 && nodeState[i] == NodeStatus.Unvisited)
                    {
                        queue.Enqueue(i);
                        nodeState[i] = NodeStatus.Visited;
                        nodeDistance[i] = nodeDistance[node] + 1;
                    }
                }
                nodeState[node] = NodeStatus.Completed;
            } while (queue.Any());

            return nodeDistance[endingCityId];
        }

        /// <summary>
        /// Initializes a graph based on city count an a list of routes
        /// </summary>
        /// <param name="cityCount">Count of cities in graph</param>
        /// <param name="routes">List of routes to populate in graph</param>
        /// <returns></returns>
        public static int[,] InitializeNetworkGraph(int cityCount, List<Route> routes, bool isDirectedGraph)
        {
            var networkGraph = new int[cityCount + 1, cityCount + 1];
            foreach (var route in routes)
            {
                networkGraph[route.StartingCityId, route.EndingCityId] = 1;
                if (!isDirectedGraph)
                    networkGraph[route.EndingCityId, route.StartingCityId] = 1;
            }
            return networkGraph;
        }
    }
}
