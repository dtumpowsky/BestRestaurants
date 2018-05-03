using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BestRest.Models;
using System;

namespace BestRest.Controllers
{
    public class HomeController : Controller
    {

          [HttpGet("/")]
          public ActionResult Index()
          {

         return View();
          }

          [HttpGet("/view-all-cuisine")]
          public ActionResult ViewAllCuisines()
          {

          List<Cuisine> allCuisine = Cuisine.GetAll();
         return View(allCuisine);

         }

         [HttpGet("/view-all-restaurants")]
         public ActionResult ViewAllRestaurants()
         {

         List<Restaurant> allRestaurants = Restaurant.GetAll();
        return View(allRestaurants);
         }

         [HttpGet("/create-new-restaurant")]
         public ActionResult CreateNewRestaurant()
         {
         List<Cuisine> allCuisine = Cuisine.GetAll();
        return View(allCuisine);
         }

        [HttpPost("/submit")]
        public ActionResult Submit()
        {
          int newRestaurantCuisine = int.Parse(Request.Form["restaurant-cuisine"]);
          string newRestaurantName = Request.Form["restaurant-name"];
          Restaurant newRestaurant = new Restaurant(newRestaurantName, newRestaurantCuisine);
          newRestaurant.Save(); //This line doesn't work
          return RedirectToAction();
        }
    }
}
