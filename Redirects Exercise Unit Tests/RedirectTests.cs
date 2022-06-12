using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redirects_Exercise;

namespace Redirects_Exercise_Unit_Tests
{
    /// <summary>
    /// This class holds all the unit tests.
    /// </summary>
    [TestClass]
    public class RedirectTests
    {
        /// <summary>
        /// Tests the case provided in the PDF.
        /// </summary>
        [TestMethod]
        public void DefaultTest()
        {
            //Create the initial and resulting list
            string[] toTest = new[]
            {
                "/home",
                "/our-ceo.html -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
            };

            string[] resultTest = new[]
            {
                "/home",
                "/our-ceo.html -> /about-us.html -> /about",
                "/product-1.html -> /seo"
            };

            //Get the result
            string[] actualResult = Program.GetPaths(toTest);

            //Test that the expected list and the returned list have the same elements
            CollectionAssert.AreEquivalent(resultTest, actualResult);
        }

        /// <summary>
        /// Tests the error case provided in the PDF.
        /// </summary>
        [TestMethod]
        public void DefaultErrorTest()
        {
            //Create the initial list
            string[] toTest = new[]
            {
                "/about-us.html -> /about",
                "/about -> about-us.html"
            };

            try
            {
                string[] actualResult = Program.GetPaths(toTest);
                //Fail the test if the cycle was not found
                Assert.Fail();
            }
            catch (ArgumentException) { } //Test succeeded if the exception was thrown
        }

        /// <summary>
        /// Test the program on a list of routes where one route can redirect to multiple different routes
        /// This is undefined behavior in the specification so I am allowing it.
        /// </summary>
        [TestMethod]
        public void ForkTest()
        {
            string[] toTest = new[]
            {
                "/home -> about-us.html",
                "/about-us.html -> /about",
                "/home -> /product-1.html",
                "/product-1.html -> /seo"
            };

            string[] resultTest = new[]
            {
                "/home -> /about-us.html -> /about",
                "/home -> /product-1.html -> /seo"
            };

            string[] actualResult = Program.GetPaths(toTest);

            CollectionAssert.AreEquivalent(resultTest, actualResult);
        }

        /// <summary>
        /// Tests for a cycle in a forked redirect hierarchy
        /// </summary>
        [TestMethod]
        public void ForkErrorTest()
        {
            string[] toTest = new[]
{
                "/home -> about-us.html",
                "/about-us.html -> /about",
                "/home -> /product-1.html",
                "/product-1.html -> /seo"
            };

            try
            {
                string[] actualResult = Program.GetPaths(toTest);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }

        /// <summary>
        /// Test the case where multiple routes could redirect to one route
        /// </summary>
        [TestMethod]
        public void JoinTest()
        {
            string[] toTest = new[]
            {
                "/home -> about-us.html",
                "/about-us.html -> /about",
                "/our-ceo.html -> /about-us.html"
            };

            string[] resultTest = new[]
            {
                "/home -> /about-us.html -> /about",
                "/our-ceo.html -> /about-us.html -> /about"
            };

            string[] actualResult = Program.GetPaths(toTest);

            CollectionAssert.AreEquivalent(resultTest, actualResult);
        }

        /// <summary>
        /// Test for a cycle in a joined redirect hierarchy
        /// </summary>
        [TestMethod]
        public void JoinErrorTest()
        {
            string[] toTest = new[]
            {
                "/home -> about-us.html",
                "/about-us.html -> /about",
                "/our-ceo.html -> /about-us.html",
                "/about-us.html -> /our-ceo.html"
            };

            try
            {
                string[] actualResult = Program.GetPaths(toTest);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }

        /// <summary>
        /// Tests the case where a redirect hierarchy has forks and joins
        /// </summary>
        [TestMethod]
        public void JoinForkTest()
        {
            string[] toTest = new[]
            {
                "/home -> about-us.html",
                "/about-us.html -> /about",
                "/home -> /product-1.html",
                "/product-1.html -> /seo",
                "/our-ceo.html -> /about-us.html"
            };

            string[] resultTest = new[]
            {
                "/home -> /about-us.html -> /about",
                "/home -> /product-1.html -> /seo",
                "/our-ceo.html -> /about-us.html -> /about"
            };

            string[] actualResult = Program.GetPaths(toTest);

            CollectionAssert.AreEquivalent(resultTest, actualResult);
        }
    }
}