using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Web.Helpers;
using Web.Models;


namespace Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IHostingEnvironment Environment;
        private UserOperations userOperations;
        public UserController(IHostingEnvironment _environment, IDbContextFactory<DietProjectContext> contextFactory)
        {
            userOperations = new UserOperations(contextFactory);
            Environment = _environment;
        }


        public IActionResult ChangeProfileImage(IFormFile Avatar)
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            User rawData = userOperations.Get(x => x.ID == ClaimHelper.UserID);
            try
            {
                var path = Path.Combine(Environment.WebRootPath, @"uploads\images");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = Path.Combine(path, Avatar.FileName);

                using (var fileStream = System.IO.File.Create(fileName))
                {
                    Avatar.CopyTo(fileStream);
                    rawData.Avatar = @"\uploads\images\" + Avatar.FileName;
                }

                bool insertRes = userOperations.Update(rawData);
            }
            catch
            {
                return Ok(new ResponseModel(false, "Bir problem oluştu."));
            }

            return Ok(new ResponseModel(true, "Başarıyla güncellendi."));
            //return Ok(Request.Headers["Referer"].ToString());
        }
    }
}
