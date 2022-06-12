using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redirects_Exercise
{
    /// <summary>
    /// A Class used to analyze a collection of routes and redirects and return the paths through those routes.
    /// </summary>
    public class PathAnalyzer : RouteAnalyzer
    {
        /// <summary>
        /// Analyze the routes and redirects from the iterator and return the paths through the routes.
        /// Throw an error if there is a cycle.
        /// </summary>
        /// <param name="routes">An iterablecollection containing the routes</param>
        /// <returns>An iterable collection containing the paths</returns>
        public IEnumerable<string> Process(IEnumerable<string> routes)
        {
            //Create a new list to hold the routes
            List<Route> routeGraph = new List<Route>();

            //Create a directed graph of routes and redirects
            foreach (string route in routes)
            {
                if (route.Contains("->")) //Redirect case
                {
                    //Get both routes, remove whitespace (delimiter is ->, can have leading or trailing whitespace)
                    string[] path = route.Split("->");
                    path[0] = path[0].Trim();
                    path[1] = path[1].Trim();

                    //Check if either route is already in the graph, if not insert it
                    if (!routeGraph.Any(r => r.RouteName == path[0])) {
                        routeGraph.Add(new Route(path[0]));
                    }
                    if (!routeGraph.Any(r => r.RouteName == path[1]))
                    {
                        routeGraph.Add(new Route(path[1])); //Head marked as false later anyway, no reason to mark that here
                    }

                    //Get both routes from the graph
                    Route from = routeGraph.Single(r => r.RouteName == path[0]);
                    Route to = routeGraph.Single(r => r.RouteName == path[1]);
                    
                    //Add the redirect to from and mark to as not a head
                    from.Following.Add(to);
                    to.IsHead = false;
                }
                else if (!routeGraph.Any(r => r.RouteName == route)) //New route case; ignores duplicates
                {
                    //Add the new route to the graph
                    routeGraph.Add(new Route(route));
                }
            }

            /*
             * Check for cycles in the existing graph; because of how paths are handled, we need to start at each route instead of where paths start to be
             * thoughrough. We go until we have examined more nodes than exist in the graph, at which point we know there must be a cycle.
             * O(n^2).
             * */
            foreach (Route route in routeGraph)
            {
                CycleHelper(route, 0, routeGraph.Count);
            }

            return routes;
        }

        /// <summary>
        /// A function to detect a cycle in the graph of paths. This is done by recursing until the path has ended or a maximum depth has been reached.
        /// </summary>
        /// <param name="currRoute">The current route we are evaluating.</param>
        /// <param name="currDepth">The current depth we have explored the graph to.</param>
        /// <param name="maxDepth">The maximum possible depth.</param>
        /// <exception cref="ArgumentException">Thrown if there is a cycle.</exception>
        private void CycleHelper(Route currRoute, int currDepth, int maxDepth)
        {
            if (currDepth >= maxDepth)
            {
                throw new ArgumentException("Error: Cycle detected in graph.");
            }
            foreach (Route next in currRoute.Following)
            {
                CycleHelper(next, currDepth + 1, maxDepth);
            }
        }
    }
}
