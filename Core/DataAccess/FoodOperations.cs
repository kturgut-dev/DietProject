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
    public class FoodOperations : IBaseOperations<Food>
    {
        private DietProjectContext context;
        public FoodOperations(DietProjectContext context)
        {
            this.context = context;
        }
        public bool Add(Food entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Foods.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(Food entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Foods.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Food Get(Expression<Func<Food, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Foods.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<Food> GetAll(Expression<Func<Food, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Foods.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(Food entity)
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
