using Core.DataAccess;
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
        public MeasureUnitsOperations measureUnitsOperations { get; set; }
        public FoodOperations foodOperations { get; set; }
        public DietDetailController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            contractOperations = new ContractOperations(contextFactory);
            dietDetailOperations = new DietDetailOperations(contextFactory);
            userOperations = new UserOperations(contextFactory);
            customerOperations = new CustomerOperations(contextFactory);
            foodOperations = new FoodOperations(contextFactory);
            measureUnitsOperations = new MeasureUnitsOperations(contextFactory);
        }

        [HttpGet("/DietDetail/Scheduler/{contarctId}")]
        public IActionResult Index(Int64 contarctId)
        {
            DietDetailViewData viewData = new DietDetailViewData();
            List<DietDetailDTO> res = new List<DietDetailDTO>();
            ClaimHelper.SetUserIdentity(User.Identity);

            if (contarctId != -1)
            {

                Contract contract = contractOperations.Get(x => x.ID == contarctId);

                var dates = new List<DateTime>();

                int index = 1;
                for (DateTime dt = contract.ContractStartDate; dt <= contract.ContractEndDate; dt = dt.AddDays(1))
                {
                    IList<DietDetail> dtList = (dietDetailOperations.GetAll(x => x.ContractID == contarctId && x.CreatedDate == dt).ToList());
                    if (dtList.ToList().Count > 0)
                    {
                        DietDetailDTO row = new DietDetailDTO();
                        row.Date = dt;
                        row.DayName = index.ToString() + ". Gün (" + dt.ToString("dd.MM.yyyy") + ")";

                        res.Add(row);
                    }

                    index++;
                }

                viewData.UserData = userOperations.Get(x => x.ID == contract.CustomerID);
                viewData.CustomerData = customerOperations.Get(x => x.UserID == contract.CustomerID);
                viewData.DietDetailData = res;
                viewData.ContractData = contract;

            }
            else
            {

            viewData.UserData = userOperations.Get(x => x.ID == ClaimHelper.UserID);
            viewData.CustomerData = customerOperations.Get(x => x.UserID == ClaimHelper.UserID);
            viewData.DietDetailData = res;
            }

            return View(viewData);
        }

        [HttpPost("/DietDetail/Scheduler/{contarctId}")]
        public ActionResult Index(Int64 contarctId, DietCreateDTO collection)
        //public ActionResult SaveList(IFormCollection collection)
        {
            Contract contract = contractOperations.Get(x => x.ID == contarctId);

            for (int i = 0; i < collection.Foods.Length; i++)
            {
                DietDetail row = new DietDetail();
                row.ContractID = contarctId;
                row.DietitianID = contract.DietitanID;
                row.CustomerID = contract.CustomerID;
                row.CreatedDate = collection.CreatedDate;
                //row.CreatedDate = DateTime.Now;

                row.Quantity = collection.Quantity[i];
                row.FoodID = collection.Foods[i];
                row.MealType = collection.MealType[i];
                row.MeasureUnitID = collection.MeasureUnit[i];

                bool insertRes = dietDetailOperations.Add(row);
                if (!insertRes)
                {
                    ViewData["response"] = new ResponseModel(false, "Kayıt oluşturulurken bir sorun oluştu.");
                    break;
                }
            }

            ViewData["response"] = new ResponseModel(true, "Kayıt başarıyla oluşturuldu.");

            #region ViewData Init
            DietDetailViewData viewData = new DietDetailViewData();
            List<DietDetailDTO> res = new List<DietDetailDTO>();
            ClaimHelper.SetUserIdentity(User.Identity);
            //Contract contract = contractOperations.Get(x => x.ID == contarctId);

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
            viewData.UserData = userOperations.Get(x => x.ID == contract.CustomerID);
            viewData.CustomerData = customerOperations.Get(x => x.UserID == contract.CustomerID);
            viewData.DietDetailData = res;
            viewData.ContractData = contract;
            #endregion


            return View(viewData);
        }

        [HttpPost("/DietDetail/Details/{contarctId}")]
        public ActionResult Details(Int64 contarctId, IFormCollection collection)
        {
            IList<DietDetail> list = dietDetailOperations.GetAll(x => x.ContractID == contarctId && x.CreatedDate == Convert.ToDateTime(collection["selectedDate"]));

            List<object> resList = new List<object>();
            foreach (DietDetail detail in list)
            {
                object row = new
                {
                    detail.ID,
                    FoodName = foodOperations.Get(x => x.ID == detail.FoodID).FoodName,
                    MeasureUnit = measureUnitsOperations.Get(x => x.ID == detail.MeasureUnitID).MeasureUnitName,
                    detail.Quantity,
                    detail.MealType,
                    detail.IsCompleted,
                };

                resList.Add(row);
            }

            return Ok(new ResponseModel(true, "OK", resList));
        }

        [HttpPost("/DietDetail/Delete/{contarctId}")]
        public IActionResult Delete(Int64 contarctId, IFormCollection collection)
        {
            IList<DietDetail> list = dietDetailOperations.GetAll(x => x.ContractID == contarctId && x.CreatedDate == Convert.ToDateTime(collection["selectedDate"]));
            foreach (DietDetail item in list)
            {
                dietDetailOperations.Delete(item);
            }

            return Ok(new ResponseModel(true, "Başarıyla kayıtlar silindi."));
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
