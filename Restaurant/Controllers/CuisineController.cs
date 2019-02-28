using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class CuisinesController : Controller
    {
      [HttpGet("/Cuisines")]
      public ActionResult Index()
      {
        List<Cuisine> allCuisines = Cuisine.GetAll();
        return View(allCuisines);
      }
    }
}
