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
    public class UserOperations : IBaseOperations<User>
    {
        public bool Add(User entity)
        {
            using (DietProjectContext context = new DietProjectContext())
            {
                try
                {
                    context.Users.Add(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(User entity)
        {
            using (DietProjectContext context = new DietProjectContext())
            {
                try
                {
                    context.Users.Remove(entity);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public User Get(Expression<Func<User, bool>> prop)
        {
            using (DietProjectContext context = new DietProjectContext())
            {
                try
                {
                    return context.Users.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<User> GetAll(Expression<Func<User, bool>> prop)
        {
            using (DietProjectContext context = new DietProjectContext())
            {
                try
                {
                    return context.Users.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(User entity)
        {
            using (DietProjectContext context = new DietProjectContext())
            {
                try
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
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
