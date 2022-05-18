using Core.DataAccess;
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
    public class MeasureUnitsController : Controller
    {
        public MeasureUnitsOperations measureUnitsOperations { get; set; }
        public MeasureUnitsController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            measureUnitsOperations = new MeasureUnitsOperations(contextFactory);
        }

        [HttpGet("/MeasureUnits")]
        public IActionResult Index()
        {
            var res = measureUnitsOperations.GetAll();
            return Ok(res);
        }
    }
}
