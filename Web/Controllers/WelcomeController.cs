using DietProject.Business.Validations;
using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Web.Models;

namespace Web.Controllers
{
    public class WelcomeController : Controller
    {
        private IHostingEnvironment Environment;
        private DietitianOperations _dietitianOperations;
        private CustomerOperations _CustomerOperations;
        public WelcomeController(IHostingEnvironment _environment, IDbContextFactory<DietProjectContext> contextFactory)
        {
            Environment = _environment;
            _dietitianOperations = new DietitianOperations(contextFactory);
            _CustomerOperations = new CustomerOperations(contextFactory);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Customer()
        {

            return View(DateLookupDataSources());
        }

        [HttpPost]
        public IActionResult Customer(Customer submitData)
        {
            CustomerValidation customerValidation = new CustomerValidation();
            ValidationResult validRes = customerValidation.Validate(submitData);
            if (!validRes.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (var err in validRes.Errors)
                {
                    errors.Add(String.Format("<p>{0}</p>", err.ErrorMessage));
                }

                return Ok(new
                {
                    IsSuccess = false,
                    Message = "Lütfen formu eksiksiz doldurunuz.",
                    RedirectUrl = "/Welcome/Customer",
                    Errors = errors
                });
            }

            Helpers.ClaimHelper.SetUserIdentity(User.Identity);
            submitData.UserID = Helpers.ClaimHelper.UserID;
            bool res = _CustomerOperations.Add(submitData);
            return Ok(new
            {
                IsSuccess = res,
                Message = res ? "Üyelik işlemleriniz başarıyla tamamlanmıştır, yönlendiriliyorsunuz." : "Bir hata oluştu.",
                RedirectUrl = "/",
                Errors = new List<string>()
            });
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

        private DateLookupDataSource DateLookupDataSources()
        {
            try
            {
                DateLookupDataSource jsonData = new DateLookupDataSource();

                List<LookupEditDataSource> daysDataSource = new List<LookupEditDataSource>();
                for (int i = 1; i < 32; i++)
                    daysDataSource.Add(new LookupEditDataSource(i.ToString(), i.ToString()));

                jsonData.Days = daysDataSource;

                List<LookupEditDataSource> monthDataSource = new List<LookupEditDataSource>();
                string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;

                for (int i = 1; i < monthNames.Length; i++)
                    monthDataSource.Add(new LookupEditDataSource(monthNames[i - 1], i.ToString()));

                jsonData.Months = monthDataSource;

                List<LookupEditDataSource> yearsDataSource = new List<LookupEditDataSource>();

                int minDate = DateTime.Now.AddYears(-10).Year;
                int maxDate = DateTime.Now.AddYears(-80).Year;
                for (int i = 0; i < minDate - maxDate; i++)
                    yearsDataSource.Add(new LookupEditDataSource(DateTime.Now.AddYears(-(i + 10)).Year.ToString(), DateTime.Now.AddYears(-i).Year.ToString()));

                jsonData.Years = yearsDataSource;
                jsonData.CustomerData = new Customer();
                return jsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
