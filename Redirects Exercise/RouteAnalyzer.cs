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
        /// <param name="routes">An iterator for the elements in a collection</param>
        /// <returns>An iterator to a collection of analyzed routes</returns>
        public IEnumerable<string> Process(IEnumerable<string> routes);
    }
}
