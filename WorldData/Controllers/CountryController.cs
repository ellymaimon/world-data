using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;

namespace WorldData.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet("/country")]
        public ActionResult Index()
        {
            List<Country> allCountries = Country.GetAll();
            return View(allCountries);
        }

        [HttpGet("/country/name")]
        public ActionResult SortByCountry()
        {
            List<Country> allCountries = Country.SortBy("Name", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }

        [HttpGet("/country/continent")]
        public ActionResult SortByContinent()
        {
            List<Country> allCountries = Country.SortBy("Continent", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }

        [HttpGet("/country/population")]
        public ActionResult SortByPopulation()
        {
            List<Country> allCountries = Country.SortBy("Population", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }

        [HttpGet("/country/life")]
        public ActionResult SortByLife()
        {
            List<Country> allCountries = Country.SortBy("LifeExpectancy", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }
    }
}
