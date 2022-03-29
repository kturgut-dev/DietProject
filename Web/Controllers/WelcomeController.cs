using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Web.Models;

namespace Web.Controllers
{
    public class WelcomeController : Controller
    {
        private IHostingEnvironment Environment;
        private DietitianOperations _dietitianOperations;
        public WelcomeController(IHostingEnvironment _environment, IDbContextFactory<DietProjectContext> contextFactory)
        {
            Environment = _environment;
            _dietitianOperations = new DietitianOperations(contextFactory);
        }
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
        public IActionResult Dietitian(float MonthlyPrice, string CityName, IFormFile CertificatePath)
        {
            Dietitian dietitian = new Dietitian();
            dietitian.MonthlyPrice = MonthlyPrice;
            dietitian.CityName = CityName;
            dietitian.IsCertificate = false;

            List<Claim> claims = ((ClaimsIdentity?)User.Identity).Claims.ToList();
            string userID = claims?.FirstOrDefault(x => x.Type.Equals("UserID", StringComparison.OrdinalIgnoreCase))?.Value;

            dietitian.UserID = Convert.ToInt64(userID);

            try
            {
                var path = Path.Combine(Environment.WebRootPath, @"uploads\images");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = Path.Combine(path, CertificatePath.FileName);

                using (var fileStream = System.IO.File.Create(fileName))
                {
                    CertificatePath.CopyTo(fileStream);
                    dietitian.CertificatePath = @"\uploads\images\" + CertificatePath.FileName;
                }

                bool insertRes = _dietitianOperations.Add(dietitian);

                ViewData["ViewMessage"] = new ViewMessage("Hesabınız onay sürecindedir, sabrınız teşşekkür ederiz.", "success");
                return Redirect("/");
            }
            catch
            {
                Response.StatusCode = 400;
                ViewData["ViewMessage"] = new ViewMessage("Bir problem oluştu, daha snra tekrar deneyiniz.", "danger");
            }

            return View();
        }

        public IActionResult CityList()
        {
            try
            {
                string folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\city.json");
                string JSON = System.IO.File.ReadAllText(folderDetails);

                //string folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\city.json");
                //List<City> account = JsonConvert.DeserializeObject<List<City>>(folderDetails);

                return Ok(JSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
