using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRest;
using System;
using Microsoft.AspNetCore.Mvc;

namespace BestRest
{
    public class Cuisine
    {
        private int _id;
        private string _type;

        public Cuisine(int Id = 0, string Type)
        {
            _id = Id;
            _type = Type;

        }

        public int GetId()
        {
          return _id;
        }

        public string GetType()
        {
          return _type;
        }
    }
}
