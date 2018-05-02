using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRest;
using System;
using Microsoft.AspNetCore.Mvc;

namespace BestRest.Models
{
    public class Restaurants
    {
        private string _littleWorld;
        private string _dinTaiFung;
        private string _senorMoose;
        private string _albertos;
        private string _spiceKing;
        private string _tasteOfIndia;
        private string _singTongThai;
        private string _thai65;
        private string _sunnyTeryaki;
        private string _hamanasu;
        private string _madGreek;
        private string _gyroStop;
        private int _cuisineId;
        private int _id;

        public Restaurants(string littleWorld, string dinTaiFung, string senorMoose, string albertos, string spiceKing, string tasteOfIndia, string singTongThai, string thai65, string sunnyTeryaki, string hamanasu, string madGreek, string gyroStop, int cuisineId,int id=0)
        {
            _littleWorld = littleWorld;
            _dinTaiFung = dinTaiFung;
            _senorMoose = senorMoose;
            _albertos = albertos;
            _spiceKing = spiceKing;
            _tasteOfIndia = tasteOfIndia;
            _singTongThai = singTongThai;
            _thai65 = thai65;
            _sunnyTeryaki = sunnyTeryaki;
            _hamanasu = hamanasu;
            _madGreek = madGreek;
            _gyroStop = gyroStop;
            _cuisineId = cuisineId;
            _id = id;
        }
    }
}
