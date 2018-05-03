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

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restaurant (name, cuisine_id) VALUES (@name, @cuisine_id);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            MySqlParameter cuisineId = new MySqlParameter();
            cuisineId.ParameterName = "@cuisine_id";
            cuisineId.Value = this._cuisineId;
            cmd.Parameters.Add(cuisineId);


            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Restaurant> GetAll()
        {
            List<Restaurant> allRestaurants = new List<Restaurant> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurants;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int restaurantId = rdr.GetInt32(0);
              string restaurantName = rdr.GetString(1);
              int cuisineId = rdr.GetInt32(2);
              Restaurant newRestaurant = new Restaurant(restaurantName, cuisineId, restaurantId);
              allRestaurants.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allRestaurants;
        }

        public static Restaurant Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurants WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int restaurantId = 0;
            string restaurantName = "";
            int restaurantCuisineId = 0;

            while(rdr.Read())
            {
              restaurantId = rdr.GetInt32(0);
              restaurantName = rdr.GetString(1);
              restaurantCuisineId = rdr.GetInt32(2);
            }
            Restaurant newRestaurant = new Restaurant(restaurantName, restaurantCuisineId, restaurantId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newRestaurant;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurants;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
