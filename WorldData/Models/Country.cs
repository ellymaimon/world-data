using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
    public class Country
    {
      private string _name;
      private string _continent;
      private int _population;
      private double _lifeExpect;

      public Country(string countryName, string continent, int population, double lifeExpectancy)
      {
        _name = countryName;
        _continent = continent;
        _population =  population;
        _lifeExpect =  lifeExpectancy;
      }

      public string GetName()
      {
        return _name;
      }

      public string GetContinent()
      {
        return _continent;
      }

      public int GetPopulation()
      {
        return _population;
      }

      public double GetLifeExpecancy()
      {
        return _lifeExpect;
      }

      //...GETTERS AND SETTERS WILL GO HERE...

      public static List<Country> GetAll()
      {
        List<Country> allCountries = new List<Country> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM country";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string countryName = rdr.GetString(1);
          string continent = rdr.GetString(2);
          int population = rdr.GetInt32(6);
          double lifeExpectancy = rdr.GetDouble(7);

          Country newCountry = new Country(countryName, continent, population, lifeExpectancy);
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
