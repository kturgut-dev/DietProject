using Core.DataAccess;
using DietProject.WisejWeb.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DietProject.WisejWeb.DataAccess
{
    public class MessageOperations : BaseDataAccess<Message>
    {
        //public MessageOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }

        //public MessageOperations() : base(new MigrationsContextFactory()) { }

        public List<Message> GetLastMessagesUser(Int64 UserID)
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {
                    return context.Set<Message>()
                          .SqlQuery("exec dbo.spSelectMessagesGrouping {0}", UserID)
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
            using (DbContext context = new DietProjectContext())
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
