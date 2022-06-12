using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redirects_Exercise
{
    /// <summary>
    /// The interface used to analyze a collection of routes
    /// </summary>
    public interface RouteAnalyzer
    {
        /// <summary>
        /// Process a collection of routes
        /// </summary>
        /// <param name="routes">An iterable collection for the elements in a collection</param>
        /// <returns>An iterable collection of analyzed routes</returns>
        public IEnumerable<string> Process(IEnumerable<string> routes);
    }
}
