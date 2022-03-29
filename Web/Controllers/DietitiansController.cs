using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class DietitiansController : Controller
    {
        public DietitianOperations _dietitianOperations { get; set; }
        public DietitiansController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            _dietitianOperations= new DietitianOperations(contextFactory);
        }
        // GET: DietitiansController
        public ActionResult Index()
        {
            IList<Dietitian> dietitianList = _dietitianOperations.GetAll();
            return View(dietitianList);
        }

        // GET: DietitiansController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
