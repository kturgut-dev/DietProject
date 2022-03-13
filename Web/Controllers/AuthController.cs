using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Web.Helpers;

namespace DietProject.Web.Controllers
{
    //https://demos.devexpress.com/aspnetcore/
    //https://demos.devexpress.com/ASPNetCore/Demo/Form/CustomizeItem/NetCore/Light/
    public class AuthController : Controller
    {
        private readonly UserOperations _UserOperations;
        public AuthController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            _UserOperations = new UserOperations(contextFactory);
        }

        public IActionResult Index()
        {
            return RedirectToPage(nameof(Login));
        }

        [HttpGet, Route("Login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");
            ViewData["Title"] = "Giriş Yap";
            return View();
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([CustomizeValidator(Properties = "EPosta,Password")] User submitData)
        {
            try
            {
                //ModelState.Clear();
                User userExists = _UserOperations.Login(submitData.EPosta.Trim(), HashHelpers.MD5Hash(submitData.Password));
                if (userExists == null)
                {
                    ViewBag.ViewMessage = "E-Posta ya da şifreniz hatalıdır.";
                    submitData.Password = string.Empty;
                    return View(submitData);
                }

                if (!userExists.IsActive)
                {
                    ViewBag.ViewMessage = "E-Posta adresiniz doğrulanmamıştır. Size gönderilen mail üzerinden doğruluyanız.";
                    submitData.Password = string.Empty;
                    return View(submitData);
                }

                List<Claim> loginClaims = new List<Claim>()
                {
                    new Claim("UserID",userExists.ID.ToString()),
                    new Claim("EPosta",userExists.EPosta),
                    new Claim("FullName",userExists.FullName),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Redirect("/");
            }
            catch (Exception e)
            {
                ViewBag.ViewMessage = "Bir sorun oluştu. Daha sonra tekrar deneyiniz.";
                submitData.Password = string.Empty;
                return View(submitData);
            }
        }

        [HttpGet, Route("Register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");
            ViewData["Title"] = "Kayıt Ol";
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, Route("Register")]
        public IActionResult Register(User submitData)
        {
            try
            {
                User emailIsExists = _UserOperations.Get(x => x.EPosta == submitData.EPosta);
                if (emailIsExists != null)
                {
                    ViewBag.ViewMessage = "Bu eposta adresine ait hesap mevcuttur.";
                    submitData.Password = string.Empty;
                    return View(submitData);
                }

                submitData.Password = HashHelpers.MD5Hash(submitData.Password);
                bool isSuccess = _UserOperations.Add(submitData);
                if (isSuccess)
                {
                    //Mail Gönderme Operasyonları

                    return RedirectToAction(nameof(Login));
                }
                else
                    ViewBag.ViewMessage = "Hesap oluşturulurken bir sorun oluştu.";

                submitData.Password = string.Empty;
                return View(submitData);
            }
            catch (Exception e)
            {
                ViewBag.ViewMessage = "Kayıt oluşturulurken bir sorun oluştu.";
                submitData.Password = string.Empty;
                return View(submitData);
            }
        }

        [HttpGet, Authorize, Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
