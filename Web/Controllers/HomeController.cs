using Core.DataAccess;
using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Helpers;
using Web.Models;


namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public UserOperations userOperations { get; set; }
        public DietitianOperations dietitianOperations { get; set; }
        public CommentOperations commentOperations { get; set; }
        public ContractOperations contractOperations { get; set; }
        public DietDetailOperations dietDetailOperations { get; set; }
        public FoodOperations foodOperations { get; set; }
        public MeasureUnitsOperations measureUnitsOperations { get; set; }
        public HomeController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            userOperations = new UserOperations(contextFactory);
            dietitianOperations = new DietitianOperations(contextFactory);
            commentOperations = new CommentOperations(contextFactory);
            contractOperations = new ContractOperations(contextFactory);
            dietDetailOperations = new DietDetailOperations(contextFactory);
            foodOperations = new FoodOperations(contextFactory);
            measureUnitsOperations = new MeasureUnitsOperations(contextFactory);
        }
        public IActionResult Index()
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            HomeViewData viewData = new HomeViewData();
            viewData.Sliders.Add(new Slider() { ImageUrl = "https://picsum.photos/1920/1080" });
            viewData.Sliders.Add(new Slider() { ImageUrl = "https://picsum.photos/1920/1080" });
            IList<Dietitian> dietitians = dietitianOperations.GetAllTOPDietitians();

            foreach (Dietitian dietitian in dietitians)
            {
                ContractDietitians row = new ContractDietitians();
                row.DietitianID = dietitian.ID;
                row.DietitianName = userOperations.Get(x => x.ID == dietitian.UserID).FullName;
                row.Avatar = userOperations.Get(x => x.ID == dietitian.UserID).Avatar;
                row.Bio = dietitian.Bio;
                viewData.PopulerDietitians.Add(row);
            }

            IList<Contract> contracts = contractOperations.GetAll(x => x.IsApproved == true && x.ContractEndDate >= DateTime.Today && x.ContractStartDate <= DateTime.Today && x.CustomerID == ClaimHelper.UserID);
            foreach (Contract item in contracts)
            {
                IList<DietDetail> details = dietDetailOperations.GetAll(x => x.ContractID == item.ID);

                foreach (DietDetail detail in details)
                {
                    string foodName = foodOperations.Get(x => x.ID == detail.FoodID).FoodName;
                    string measureUnitName = measureUnitsOperations.Get(x => x.ID == detail.MeasureUnitID).MeasureUnitName;
                    Calender row = new Calender();
                    row.StartDate = detail.CreatedDate;
                    row.EndDate = detail.CreatedDate;
                    row.Text = string.Format("{0} {1} {2} - {3}", detail.Quantity, measureUnitName, foodName, detail.MealType);
                    viewData.Calender.Add(row);
                }


                ContractDietitians dietRow = new ContractDietitians();
                dietRow.DietitianID = item.DietitanID;
                dietRow.DietitianName = userOperations.Get(x => x.ID == item.DietitanID).FullName;
                dietRow.Avatar = userOperations.Get(x => x.ID == item.DietitanID).Avatar;
                dietRow.Bio = dietitianOperations.Get(x => x.UserID == item.DietitanID).Bio;
                viewData.Dietitians.Add(dietRow);
            }

            return View(viewData);
        }

        public IActionResult UserData()
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            return Ok(new
            {
                FullName = ClaimHelper.FullName,
                EPosta = ClaimHelper.EPosta,
                Avatar = userOperations.Get(x => x.ID == ClaimHelper.UserID).Avatar
            });
        }

        public IActionResult Menus()
        {
            ClaimHelper.SetUserIdentity(User.Identity);

            IList<object> menus = new List<object>();

            menus.Add(new
            {
                Url = "/",
                Text = "Anasayfa"
            });

            menus.Add(new
            {
                Url = "/portal",
                Text = "Portal"
            });
            if (ClaimHelper.IsAdmin)
            {
                menus.Add(new
                {
                    Url = "/Dietitians/Index",
                    Text = "Diyetisyenler"
                });
            }
            menus.Add(new
            {
                Url = "/Chat/Index",
                Text = "Sohbet"
            });
            menus.Add(new
            {
                Url = "/Account",
                Text = "Hesabım"
            });
            return Ok(menus);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
