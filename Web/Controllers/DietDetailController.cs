using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class DietDetailController : Controller
    {
        public UserOperations userOperations { get; set; }
        public CustomerOperations customerOperations { get; set; }
        public ContractOperations contractOperations { get; set; }
        public DietDetailOperations dietDetailOperations { get; set; }
        public DietDetailController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            contractOperations = new ContractOperations(contextFactory);
            dietDetailOperations = new DietDetailOperations(contextFactory);
            userOperations = new UserOperations(contextFactory);
            customerOperations = new CustomerOperations(contextFactory);
        }

        [HttpGet("/DietDetail/Scheduler/{contarctId}")]
        public IActionResult Index(Int64 contarctId)
        {
            DietDetailViewData viewData = new DietDetailViewData();
            List<DietDetailDTO> res = new List<DietDetailDTO>();
            ClaimHelper.SetUserIdentity(User.Identity);
            Contract contract = contractOperations.Get(x => x.ID == contarctId);

            var dates = new List<DateTime>();

            int index = 1;
            for (DateTime dt = contract.ContractStartDate; dt <= contract.ContractEndDate; dt = dt.AddDays(1))
            {
                if ((dietDetailOperations.GetAll(x => x.ContractID == contarctId && x.CreatedDate == dt).ToList().Count > 0))
                {
                    DietDetailDTO row = new DietDetailDTO();
                    row.Date = dt;
                    row.DayName = index.ToString() + ". Gün (" + dt.ToString("dd.MM.yyyy") + ")";

                    res.Add(row);
                }

                index++;
            }
            viewData.UserData = userOperations.Get(x=>x.ID == contract.CustomerID);
            viewData.CustomerData = customerOperations.Get(x=>x.UserID == contract.CustomerID);
            viewData.DietDetailData = res;
            return View(viewData);
        }

        [HttpPost("/DietDetail/Scheduler/{contarctId}")]
        public ActionResult SaveList(Int64 contarctId,DietCreateDTO collection)
        //public ActionResult SaveList(IFormCollection collection)
        {

            return Ok();
        }

        [HttpGet("/DietDetail/Delete/{dietDetailId}")]
        public IActionResult Delete(Int64 dietDetailId)
        {
            dietDetailOperations.Delete(dietDetailOperations.Get(x => x.ID == dietDetailId));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("/DietDetail/Edit")]
        public IActionResult Edit(DietDetail postData)
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            dietDetailOperations.Update(postData);
            return RedirectToAction(nameof(Index));
        }
    }
}
