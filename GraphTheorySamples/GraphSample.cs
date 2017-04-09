using System.Collections.Generic;
using System.Linq;

namespace GraphTheorySamples
{
    public static class BFSGraphSample
    {
        public static int GetHopsFromSourceToDestination(int startingCityId, int endingCityId, List<Route> routes, List<CityNode> cities)
        {
            // Initialize Graph
            var graph = InitializeNetworkGraph(cities.Count, routes);
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

        public static int[,] InitializeNetworkGraph(int cityCount, List<Route> routes)
        {
            var networkGraph = new int[cityCount + 1, cityCount + 1];
            foreach (var route in routes)
            {
                networkGraph[route.StartingCityId, route.EndingCityId] = 1;
                networkGraph[route.EndingCityId, route.StartingCityId] = 1;
            }
            return networkGraph;
        }
    }
}
