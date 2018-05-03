using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRest.Models;
using System;

namespace BestRest.Tests
{
    [TestClass]
    public class RestaurantTests : IDisposable
    {
        public void Dispose()
        {
            Restaurant.DeleteAll();
        }
        public RestaurantTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
        }

        [TestMethod]
        public void Restaurant_isEmpty()
        {
            int result = Restaurant.GetAll().Count;

            Assert.AreEqual(0, result);
        }
    }

    [TestClass]
    public class CuisineTests
    {
        public CuisineTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
        }

        [TestMethod]
        public void Cuisine_returns_Chinese()
        {
            Cuisine result = Cuisine.Find(3);
            string finalResult = result.GetCuisineType();

            Assert.AreEqual("indian", finalResult);
        }
    }
}
