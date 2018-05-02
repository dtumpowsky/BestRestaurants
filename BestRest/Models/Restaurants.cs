using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRest;
using System;
using Microsoft.AspNetCore.Mvc;

namespace BestRest.Models
{
    public class Restaurant
    {
        private string _name;
        private int _cuisineId;
        private int _id;

        public Restaurant(string name, int cuisineId, int id=0)
        {
            _name = name;
            _cuisineId = cuisineId;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string Name)
        {
            _name = Name;
        }

        public int GetRestaurantId()
        {
            return _id;
        }

        public int GetCuisineId()
        {
            return _cuisineId;
        }


        public override bool Equals(System.Object otherItem)
        {
          if (!(otherItem is Restaurant))
          {
            return false;
          }
          else
          {
             Restaurant newRestaurant = (Restaurant) otherItem;
             bool idEquality = this.GetRestaurantId() == newRestaurant.GetRestaurantId();
             bool nameEquality = this.GetName() == newRestaurant.GetName();
             bool cuisineEquality = this.GetCuisineId() == newRestaurant.GetCuisineId();
             return (idEquality && nameEquality && cuisineEquality);
           }
        }
    }
}
