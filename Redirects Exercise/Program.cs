using System;
using System.IO;
using System.Linq;

namespace Redirects_Exercise
{

    /// <summary>
    /// Base class, holds the program's driver
    /// </summary>
    public class Program 
    {
        //A singleton PathAnalyzer object to do all the heavy lifting
        static PathAnalyzer pathAnalyzer = new PathAnalyzer();

        /// <summary>
        /// Main driver for the program; runs the test case through GetPaths and prints the paths to the console.
        /// </summary>
        public static void Main()
        {
            string[] routes = new[]
            {
                "/home",
                "/our-ceo.html -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
            };

            string[] paths = GetPaths(routes);

            foreach (string toPrint in paths)
                Console.WriteLine(toPrint);
        }

        /// <summary>
        /// Takes a list of routes and redirects in an application and returns a list of paths.
        /// </summary>
        /// <param name="routes">The routes</param>
        /// <returns>A list of paths</returns>
        public static string[] GetPaths(string[] routes)
        {
            return pathAnalyzer.Process(routes).ToArray();
        }
    }
}