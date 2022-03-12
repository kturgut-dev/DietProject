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
    public class DietitianOperations : IBaseOperations<Dietitian>
    {
        private DietProjectContext context;
        public DietitianOperations(DietProjectContext context)
        {
            this.context = context;
        }
        public bool Add(Dietitian entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Dietitians.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(Dietitian entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Dietitians.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Dietitian Get(Expression<Func<Dietitian, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Dietitians.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<Dietitian> GetAll(Expression<Func<Dietitian, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Dietitians.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(Dietitian entity)
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
