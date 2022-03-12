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
    public class CustomerOperations : IBaseOperations<Customer>
    {
        private DietProjectContext context;
        public CustomerOperations(DietProjectContext context)
        {
            this.context = context;
        }
        public bool Add(Customer entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Customers.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(Customer entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Customers.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Customers.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<Customer> GetAll(Expression<Func<Customer, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Customers.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(Customer entity)
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
