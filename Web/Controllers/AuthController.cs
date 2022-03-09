using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietProject.Web.Controllers
{
    //https://demos.devexpress.com/aspnetcore/
    //https://demos.devexpress.com/ASPNetCore/Demo/Form/CustomizeItem/NetCore/Light/
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToPage(nameof(Login));
        }

        [Route("Login")]
        public IActionResult Login()
        {
            ViewData["Title"] = "Giriş Yap";
            return View();
        }

        [Route("Register")]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kayıt Ol";
            return View();
        }
    }
}
