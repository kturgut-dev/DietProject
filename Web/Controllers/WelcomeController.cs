using DietProject.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;

namespace Web.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Customer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Customer(Customer submitData)
        {
            return View();
        }

        public IActionResult Dietitian()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dietitian(Dietitian submitData)
        {
            //resim yukleme yapılacak
            //ayarlar kaydedilecek
            return View();
        }

        public IActionResult CityList()
        {
            try
            {
                string folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\city.json");
                string JSON = System.IO.File.ReadAllText(folderDetails, Encoding.Default);
               
                return Ok(JSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
