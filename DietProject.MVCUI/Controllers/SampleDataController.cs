using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DietProject_MVCUI.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace DietProject_MVCUI.Controllers {
    public class SampleDataController : ApiController {

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            return Request.CreateResponse(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }

    }
}