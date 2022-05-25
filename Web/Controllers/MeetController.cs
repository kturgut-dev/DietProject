using Core.Entities;
using DietProject.Core.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class MeetController : Controller
    {
        public MeetingOperations meetingOperations { get; set; }
        public UserOperations userOperations { get; set; }
        public MeetController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            meetingOperations = new MeetingOperations(contextFactory);
            userOperations = new UserOperations(contextFactory);
        }

        [HttpGet("/Meet/{dietitianUserId}")]
        public IActionResult GetAll(Int64 dietitianUserId, [FromQuery(Name = "date")]DateTime. date)
        {
            //ClaimHelper.SetUserIdentity(User.Identity);
            return Ok(new ResponseModel(true, "OK", meetingOperations.GetAll(x => x.DietitianID == dietitianUserId)));
        }

        [HttpPost]
        public IActionResult Add(IFormCollection collection)
        {
            ClaimHelper.SetUserIdentity(User.Identity);

            Meeting postData = new Meeting();
            postData.DietitianID = ClaimHelper.UserID;
            postData.SelectedDate = Convert.ToDateTime(collection["SelectedDate"]);
            postData.CustomerID = Convert.ToInt64(collection["CustomerID"]);

            if (meetingOperations.GetAll(x => x.DietitianID == ClaimHelper.UserID && x.SelectedDate == postData.SelectedDate).Count > 0)
                return Ok(new ResponseModel(false, "Seçtiğiniz tarihe ait zaten randevu bulunmaktadır."));

            bool res = meetingOperations.Add(postData);
            return Ok(new ResponseModel(res, res ? "Kayıt işlemi başarılı." : "Kayıt işlemi sırasında bir problem oluştu."));
        }

        [HttpGet("/Meet/Delete/{id}")]
        public IActionResult Delete(Int64 id)
        {
            bool res = meetingOperations.Delete(meetingOperations.Get(x => x.ID == id));
            return Ok(new ResponseModel(res, res ? "Silme işlemi başarılı." : "Silme işlemi sırasında bir problem oluştu."));
        }
    }
}
