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
    public class DietDetailOperations : IBaseOperations<DietDetail>
    {
        private DietProjectContext context;
        public DietDetailOperations(DietProjectContext context)
        {
            this.context = context;
        }
        public bool Add(DietDetail entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.DietDetails.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(DietDetail entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.DietDetails.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public DietDetail Get(Expression<Func<DietDetail, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.DietDetails.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<DietDetail> GetAll(Expression<Func<DietDetail, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.DietDetails.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(DietDetail entity)
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
