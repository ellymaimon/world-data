using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Country> allCountries = Country.GetAll();
            return View(allCountries);
        }

        [HttpGet("/country")]
        public ActionResult SortByCountry()
        {
            List<Country> allCountries = Country.SortBy("Name", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }

        [HttpGet("/continent")]
        public ActionResult SortByContinent()
        {
            List<Country> allCountries = Country.SortBy("Continent", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }

        [HttpGet("/population")]
        public ActionResult SortByPopulation()
        {
            List<Country> allCountries = Country.SortBy("Population", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }

        [HttpGet("/life")]
        public ActionResult SortByLife()
        {
            List<Country> allCountries = Country.SortBy("LifeExpectancy", Country.GetSortOrder());
            Country.FlipSortOrder();
            return View("Index", allCountries);
        }
    }
}
