using System.Collections.Generic;

namespace Redirects_Exercise
{
    /// <summary>
    /// Holds information about a route and outgoing redirects. Effectively a node in a linked list.
    /// </summary>
    internal class Route
    {
        //Name of the Route (/home, /about, etc.)
        public string RouteName { get; set; }
        //The nodes this Route redirects to
        public List<Route> Following { get; set; }
        //Whether or not this node is the start of a path
        public bool IsHead { get; set; }

        /// <summary>
        /// Creates a Route
        /// </summary>
        /// <param name="RouteName">The name of the new Route</param>
        /// <param name="IsHead">Whether the new Route is a head node or not</param>
        public Route(string routeName, bool isHead = false)
        {
            this.RouteName = routeName;
            this.IsHead = isHead;
            this.Following = new List<Route>();
        }
    }
}
