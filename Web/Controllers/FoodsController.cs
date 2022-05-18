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
    public class FoodsController : Controller
    {
        public FoodOperations foodOperations { get; set; }
        public FoodsController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            foodOperations = new FoodOperations(contextFactory);
        }

        [HttpGet("/Foods")]
        public IActionResult Index()
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            return Ok(foodOperations.GetAll(x => x.CreatedBy == ClaimHelper.UserID));
        }

        [HttpPost("/Foods/Create")]
        public IActionResult Create(string name)
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            bool res = foodOperations.Add(new Food()
            {
                CreatedBy = ClaimHelper.UserID,
                CreatedDate = DateTime.Now,
                FoodName = name,
            });
            return Ok(new ResponseModel(res, res ? "Kayıt başarılı." : "Bir problem oluştu."));
        }

        [HttpPost("/Foods/Delete/{Id}")]
        public IActionResult Create(Int64 Id)
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            bool res = foodOperations.Delete(foodOperations.Get(x => x.CreatedBy == ClaimHelper.UserID && x.ID == Id));
            return Ok(new ResponseModel(res, res ? "Silme işlemi başarılı." : "Bir problem oluştu."));
        }
    }
}
