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
    public class CommentOperations : IBaseOperations<Comment>
    {
        private DietProjectContext context;
        public CommentOperations(DietProjectContext context)
        {
            this.context = context;
        }
        public bool Add(Comment entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Comments.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(Comment entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Comments.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Comment Get(Expression<Func<Comment, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Comments.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<Comment> GetAll(Expression<Func<Comment, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Comments.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(Comment entity)
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
