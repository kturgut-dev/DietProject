using Core.Entities.Abstract;
using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class DietitiansController : Controller
    {
        public DietitianOperations _dietitianOperations { get; set; }
        public UserOperations _userOperations { get; set; }
        public DietitiansController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            _dietitianOperations = new DietitianOperations(contextFactory);
            _userOperations = new UserOperations(contextFactory);
        }
        // GET: DietitiansController
        public ActionResult Index()
        {
            IList<Dietitian> dietitianList = _dietitianOperations.GetAll();
            List<object> result = new List<object>();
            foreach (Dietitian dietitian in dietitianList)
            {
                result.Add(new
                {
                    ID = dietitian.ID,
                    AdSoyad = _userOperations.Get(x => x.ID == dietitian.UserID).FullName,
                    IsCertificate = dietitian.IsCertificate ? "Evet" : "Hayır",
                    IsCertificateVerDate = dietitian.IsCertificateVerDate,
                    CityName = dietitian.CityName,
                    MonthlyPrice = dietitian.MonthlyPrice
                });
            }

            return View(result);
        }

        // GET: DietitiansController/Details/5
        public ActionResult Details(Int64 id)
        {
            Dietitian result = _dietitianOperations.Get(x => x.ID == id);
            if (result == null)
                return RedirectToAction(nameof(Index));

            DietProject.Core.Entities.User resultUser = _userOperations.Get(x => x.ID == result.UserID);

            DietitianDTO res = new DietitianDTO();
            res.UserData = resultUser;
            res.DietitianData = result;

            return View(res);
        }
        public ActionResult Approve(Int64 id)
        {
            Dietitian result = _dietitianOperations.Get(x => x.ID == id);
            if (result == null)
                return RedirectToAction(nameof(Index));

            result.IsCertificate = true;
            result.IsCertificateVerDate = DateTime.Now;
            _dietitianOperations.Update(result);
            return RedirectToAction(nameof(Index));
        }
        // GET: DietitiansController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DietitiansController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DietitiansController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DietitiansController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DietitiansController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DietitiansController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
