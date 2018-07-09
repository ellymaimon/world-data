using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
    public class Country
    {
      private int _id;
      private string _name;
      private string _continent;
      private int _population;
      private int _lifeExpect;

      public Country(int Id = 0, string Name, string Continent, int Population, int LifeExpectancy )
      {
        _id = Id;
        _name = Name;
        _continent = Continent;
        _population =  Population;
        _lifeExpect =  LifeExpectancy;

      }

      //...GETTERS AND SETTERS WILL GO HERE...

          public static List<Country> GetAll()
          {
              List<Country> allCountries = new List<Country> {};
              MySqlConnection conn = DB.Connection();
              conn.Open();
              MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
              cmd.CommandText = @"SELECT * FROM items;";
              MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
              while(rdr.Read())
              {
                int itemId = rdr.GetInt32(0);
                string itemDescription = rdr.GetString(1);
                Country newCountry = new Country(itemDescription, itemId);
                allCountries.Add(newCountry);
              }
              conn.Close();
              if (conn != null)
              {
                  conn.Dispose();
              }
              return allCountries;
          }
    }
}
