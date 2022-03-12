using DietProject.Core.Entities;
using DietProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.DataAccess
{
    public class MessageOperations : IBaseOperations<Message>
    {
        private DietProjectContext context;
        public MessageOperations(DietProjectContext context)
        {
            this.context = context;
        }
        public bool Add(Message entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Messages.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(Message entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Messages.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Message Get(Expression<Func<Message, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Messages.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<Message> GetAll(Expression<Func<Message, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Messages.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(Message entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
