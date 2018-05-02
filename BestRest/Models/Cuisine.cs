using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRest;
using System;
using Microsoft.AspNetCore.Mvc;

namespace BestRest
{
    public class Cuisine
    {
      private string _chinese;
      private string _mexican;
      private string _american;
      private string _indian;
      private string _thai;
      private string _japanese;
      private string _greek;

      public Cuisine(string chinese, string mexican, string american, string indian, string thai, string japanese, string greek)
      {
          _chinese = greek;
          _mexican = mexican;
          _american = american;
          _indian = indian;
          _thai = thai;
          _japanese = japanese;
          _greek = greek;
      }
    }
}
