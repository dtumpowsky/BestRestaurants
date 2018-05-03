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
}
