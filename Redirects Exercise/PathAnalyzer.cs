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
        /// <param name="routes">An iterator to a collection containing the routes</param>
        /// <returns>An iterator to a collection containing the paths</returns>
        public IEnumerable<string> Process(IEnumerable<string> routes)
        {
            //Temporary return value
            return routes;
        }
    }
}
