using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorldData.Models;

namespace WorldData.Tests
{
    [TestClass]
    public class CityTest
    {
      [TestMethod]
      public void GetAll_GetsAllCountries_List()
      {
        Country newCountry = new Country();
        List<Country> countryList = newCountry.GetAll();
        var countryAruba = countryList[0];
        Assert.AreEqual("Aruba", countryAruba.GetName());
      }

    }
}
