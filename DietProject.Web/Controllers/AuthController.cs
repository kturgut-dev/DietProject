using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietProject.Web.Controllers
{
    public class AuthController : Controller
    {
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
