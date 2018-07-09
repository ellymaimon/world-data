using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
    public class City
    {
      private string _name;
      private string _district;
      private int _population;
      private static bool _sortOrder = false;

      public City(string cityName, string district, int population)
      {
        _name = cityName;
        _district = district;
        _population = population;
      }

      public string GetName()
      {
        return _name;
      }

      public string GetDistrict()
      {
        return _district;
      }

      public int GetPopulation()
      {
        return _population;
      }

      public static void FlipSortOrder()
      {
         _sortOrder = !_sortOrder;
      }

      public static bool GetSortOrder()
      {
        return _sortOrder;
      }

      public static List<City> GetAll()
      {
        List<City> allCities = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string cityName = rdr.GetString(1);
          string district = rdr.GetString(3);
          int population = rdr.GetInt32(4);

          City newCity = new City(cityName, district, population);
          allCities.Add(newCity);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCities;
      }

      public static List<City> SortBy(string category, bool sortOrder)
      {
        List<City> allCities = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city";
        if (sortOrder)
        {
        cmd.CommandText = @"SELECT * FROM city ORDER BY " + category + " ASC";
        }
        else
        {
        cmd.CommandText = @"SELECT * FROM city ORDER BY " + category + " DESC";
        }
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string cityName = rdr.GetString(1);
          string district = rdr.GetString(3);
          int population = rdr.GetInt32(4);

          City newCity = new City(cityName, district, population);
          allCities.Add(newCity);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCities;
      }  


    }
}
