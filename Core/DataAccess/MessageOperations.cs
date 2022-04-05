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
    }
}
