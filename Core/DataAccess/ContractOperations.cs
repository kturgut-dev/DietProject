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
    public class ContractOperations : IBaseOperations<Contract>
    {
        private DietProjectContext context;
        public ContractOperations(DietProjectContext context)
        {
            this.context = context;
        }
        public bool Add(Contract entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Contracts.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(Contract entity)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    context.Contracts.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Contract Get(Expression<Func<Contract, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Contracts.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<Contract> GetAll(Expression<Func<Contract, bool>> prop)
        {
            using (DietProjectContext context = this.context)
            {
                try
                {
                    return context.Contracts.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(Contract entity)
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
