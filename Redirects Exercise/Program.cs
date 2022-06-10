using System;
using System.IO;

namespace Redirects
{

    /// <summary>
    /// Base class, holds the program's driver
    /// </summary>
    public class Program 
    {
        /// <summary>
        /// Main driver for the program; runs the test case through GetPaths and prints the paths to the console.
        /// </summary>
        public static void Main()
        {

        }

        /// <summary>
        /// Takes a list of routes and redirects in an application and returns a list of paths.
        /// </summary>
        /// <param name="routes">The routes</param>
        /// <returns>A list of paths</returns>
        public static string[] GetPaths(string[] routes)
        {
            //Temporary return value
            return routes;
        }
    }
}