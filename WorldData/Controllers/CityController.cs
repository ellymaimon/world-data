using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;

namespace WorldData.Controllers
{
    public class CityController : Controller
    {
        [HttpGet("/city")]
        public ActionResult Index()
        {
            List<City> allCities = City.GetAll();
            return View(allCities);
        }

        [HttpGet("/city/name")]
        public ActionResult SortByCity()
        {
            List<City> allCities = City.SortBy("Name", City.GetSortOrder());
            City.FlipSortOrder();
            return View("Index", allCities);
        }

        [HttpGet("/city/district")]
        public ActionResult SortByDistrict()
        {
            List<City> allCities = City.SortBy("District", City.GetSortOrder());
            City.FlipSortOrder();
            return View("Index", allCities);
        }

        [HttpGet("/city/population")]
        public ActionResult SortByPopulation()
        {
            List<City> allCities = City.SortBy("Population", City.GetSortOrder());
            City.FlipSortOrder();
            return View("Index", allCities);
        }
    }
}
