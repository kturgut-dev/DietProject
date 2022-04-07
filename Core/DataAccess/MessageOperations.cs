using DietProject.Core.Entities;
using DietProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DietProject.Core.DataAccess
{
    public class MessageOperations : BaseDataAccess<Message>
    {
        public MessageOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }

        public List<Message> GetLastMessagesUser(Int64 UserID)
        {
            using (DbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    return context.Set<Message>().Where(x => x.SendedUserID == UserID || x.ReceiverUserID == UserID)
                          .OrderBy(x => x.MessageDate)
                          .GroupBy(l => new { l.SendedUserID, l.ReceiverUserID })
                          .Select(g => g.OrderByDescending(c => c.ID).FirstOrDefault())
                          .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Message> GetLastMessagesUser(Int64 UserID, Int64 ReciverUserID)
        {
            using (DbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    return context.Set<Message>()
                          .Where(x => (x.SendedUserID == UserID || x.ReceiverUserID == UserID) && (x.SendedUserID == ReciverUserID || x.ReceiverUserID == ReciverUserID))
                          .OrderBy(x => x.MessageDate)
                          .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
