using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Web.Helpers;

namespace DietProject.Web.Controllers
{
    //https://demos.devexpress.com/aspnetcore/
    //https://demos.devexpress.com/ASPNetCore/Demo/Form/CustomizeItem/NetCore/Light/
    public class AuthController : Controller
    {
        private readonly UserOperations _UserOperations;
        public AuthController(DietProjectContext context)
        {
            _UserOperations = new UserOperations(context);
        }

        public IActionResult Index()
        {
            return RedirectToPage(nameof(Login));
        }

        [HttpGet, Route("Login")]
        public IActionResult Login()
        {
            ViewData["Title"] = "Giriş Yap";
            return View();
        }

        [HttpPost]
        public IActionResult PostLogin()
        {
            return Redirect("/");
        }

        [HttpGet, Route("Register")]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kayıt Ol";
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult PostRegister(User submitData)
        {
            try
            {

                User emailIsExists = _UserOperations.Get(x => x.EPosta == submitData.EPosta);
                if (emailIsExists != null)
                {
                    ModelState.AddModelError("EPosta", "Bu eposta adresine ait hesap mevcuttur.");
                    return RedirectToAction(nameof(Register));
                }

                submitData.Password = HashHelpers.MD5Hash(submitData.Password);
                bool isSuccess = _UserOperations.Add(submitData);

                return RedirectToAction(nameof(Login));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("FullName", "Kayıt oluşturulurken bir sorun oluştu.");
                return RedirectToAction(nameof(Register));
            }
        }
    }
}
