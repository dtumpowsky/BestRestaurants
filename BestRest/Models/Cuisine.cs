using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRest;
using System;
using Microsoft.AspNetCore.Mvc;

namespace BestRest.Models
{
    public class Cuisine
    {
        private string _type;
        private int _id;

        public Cuisine(string Type, int Id = 0)
        {
            _type = Type;
            _id = Id;

        }

        public int GetId()
        {
          return _id;
        }

        public string GetType()
        {
          return _type;
        }

        public static List<Cuisine> GetAll()
        {
            List<Cuisine> allCuisine = new List<Cuisine> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisine;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cuisineId = rdr.GetInt32(0);
              string cuisineType = rdr.GetString(1);
              Cuisine newCuisine = new Cuisine(cuisineType, cuisineId);
              allCuisine.Add(newCuisine);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCuisine;
        }

        public static Cuisine Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisine WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int cuisineId = 0;
            string cuisineType = "";

            while(rdr.Read())
            {
              cuisineId = rdr.GetInt32(0);
              cuisineType = rdr.GetString(1);
            }
            Cuisine newCuisine = new Cuisine(cuisineType, cuisineId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newCuisine;
        }
    }
}
