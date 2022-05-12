using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Web.Helpers;

namespace Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        public CommentOperations _dietitianOperations { get; set; }
        public CustomerOperations _customerOperations { get; set; }
        public UserOperations _userOperations { get; set; }
        public CommentController(IDbContextFactory<DietProjectContext> contextFactory)
        {
            _dietitianOperations = new CommentOperations(contextFactory);
            _customerOperations = new CustomerOperations(contextFactory);
            _userOperations = new UserOperations(contextFactory);
        }

        // GET: /Comment/Dietitian/GetAll/5
        [HttpGet("/Comment/Dietitian/GetAll/{dietitianId}")]
        public ActionResult GetAll(Int64 dietitianId)
        {
            try
            {
                List<object> response = new List<object>();

                IList<Comment> commments = _dietitianOperations.GetAll(x => x.DietitianID == dietitianId);
                if (commments != null)
                    foreach (Comment comment in commments)
                    {
                        Customer cusRawData = _customerOperations.Get(x => x.ID == comment.CustomerID);
                        User commentSenderUserData = _userOperations.Get(x => x.ID == cusRawData.UserID);
                        response.Add(new
                        {
                            DataId = comment.ID,
                            Date = comment.CommentDate.ToString("dd.MM.yyyy HH:mm"),
                            Text = comment.CommentText,
                            Score = comment.Score,
                            UserData = new
                            {
                                Avatar = commentSenderUserData.Avatar,
                                FullName = commentSenderUserData.FullName
                            }
                        });
                    }
                return Ok(new { IsSuccsss = true, Comments = response, Message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { IsSuccsss = false, Comments = new List<object>(), Message = ex.Message });
            }
        }

        [HttpPost("/Comment/Create")]
        public ActionResult Create(Int64 dietitianId, string comment, int score)
        {
            try
            {
                ClaimHelper.SetUserIdentity(User.Identity);

                if (string.IsNullOrEmpty(comment.Trim()))
                    throw new Exception("Yorum boş bırakılamaz.");

                if (score == 0)
                    throw new Exception("Skor 0'dan büyük olmalıdır.");

                Comment _comment = new Comment();
                _comment.DietitianID = dietitianId;
                _comment.CommentDate = DateTime.Now;
                _comment.CommentText = comment;//bu deger gelmıor kontrol et
                _comment.Score = Convert.ToInt32(score);
                _comment.CustomerID = _customerOperations.Get(x => x.UserID == ClaimHelper.UserID).ID;

                bool isSuccesss = _dietitianOperations.Add(_comment);
                return Ok(new { IsSuccsss = isSuccesss, Message = isSuccesss ? "Yorumunuz başarıyla kaydedildi." : "Yorumunuz kaydedilirken bir sorun oluştu." });
            }
            catch (Exception ex)
            {
                return Ok(new { IsSuccsss = false, Message = ex.Message });
            }
        }

        // GET: /Comment/Delete/5
        [HttpPost("/Comment/Delete/{commentId}")]
        public ActionResult Delete(Int64 commentId)
        {
            try
            {
                Comment _comment = _dietitianOperations.Get(X => X.ID == commentId);
                if (_comment == null)
                    return Ok(new { IsSuccsss = false, Message = "Yorumunuz silinirken bir sorun oluştu." });
                else
                {
                    bool isSuccess = _dietitianOperations.Delete(_comment);
                    return Ok(new { IsSuccsss = isSuccess, Message = isSuccess ? "Yorumunuz başarıyla silindi." : "Yorumunuz silinirken bir sorun oluştu." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { IsSuccsss = true, Message = ex.Message });
            }
        }

    }
}
