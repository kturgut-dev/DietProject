using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class ContractController : Controller
    {
        public ContractOperations contractOperations { get; set; }
        public DietitianOperations dietitianOperations { get; set; }
        public UserOperations userOperations { get; set; }
        public ContractController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            contractOperations = new ContractOperations(contextFactory);
            dietitianOperations = new DietitianOperations(contextFactory);
            userOperations = new UserOperations(contextFactory);
        }

        [HttpGet("/Contract")]
        public IActionResult Index([FromQuery(Name = "userType")] string userType, [FromQuery(Name = "uId")] Int64? userId)
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            IList<Contract> rawData = null;
            if (!string.IsNullOrEmpty(userType) && userId.HasValue)
            {
                if (userType == nameof(Web.Models.UserTypes.Dietitian))
                    rawData = contractOperations.GetAll(x => x.CustomerID == ClaimHelper.UserID && x.DietitanID == userId);
                else
                    rawData = contractOperations.GetAll(x => x.DietitanID == ClaimHelper.UserID && x.CustomerID == userId);
            }
            else
            {
                rawData = contractOperations.GetAll(x => x.CustomerID == ClaimHelper.UserID);
            }

            if (rawData != null)
            {
                foreach (Contract item in rawData)
                {
                    item.DietitianData = dietitianOperations.Get(x => x.UserID == item.DietitanID);
                    item.UserDietitianData = userOperations.Get(x => x.ID == item.DietitanID);
                    item.UserCustomerData = userOperations.Get(x => x.ID == item.CustomerID);
                }
            }
            return View(rawData);
        }

        [HttpGet("/Contract/{contractId}")]
        public IActionResult Detail(Int64 contractId)
        {
            Contract rawData = contractOperations.Get(x => x.ID == contractId);
            return View(rawData);
        }

        [HttpGet("/Contract/Approve")]
        public IActionResult Approve([FromQuery(Name = "cId")] Int64 contractId, [FromQuery(Name = "approve")] int approve)
        {
            Contract rawData = contractOperations.Get(x => x.ID == contractId);
            rawData.IsApproved = approve == 1;
            bool res = contractOperations.Update(rawData);
            return RedirectToAction(nameof(Index));

            //return Ok(new ResponseModel(res, res ?
            //    "Başarıyla onaylandı." :
            //    "Onay sırasında bir problem oluştu."));
        }

        [HttpPost("/Contract")]
        public IActionResult Add(Contract submitedData)
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            submitedData.DietitanID = ClaimHelper.UserID;

            bool isSuccess = contractOperations.Add(submitedData);
            //List< Contract> rawList   contractOperations.GetAll(x=>x.CustomerID == ClaimHelper.UserID && submitedData.DietitanID == x.DietitanID)
            //       .OrderByDescending(x => x.ID)
            //           .ToList();
            return Ok(new ResponseModel(isSuccess, isSuccess ? "Teklif gönderildi." : "Teklif gönderilirken bir sorun oluştu."));
        }

        [HttpGet("/Contract/Delete/{contractId}")]
        public IActionResult Delete(Int64 contractId)
        {
            contractOperations.Delete(contractOperations.Get(x => x.ID == contractId));
            return RedirectToAction(nameof(Index));
        }
    }
}
