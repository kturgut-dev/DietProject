using DietProject.Core.Entities;
using DietProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DietProject.Core.DataAccess
{
    public class UserOperations : IBaseOperations<User>
    {
        private DietProjectContext _context;
        public UserOperations(DietProjectContext context)
        {
            _context = context;
        }
        public bool Add(User entity)
        {
            using (_context)
            {
                try
                {
                    _context.Users.AddAsync(entity)
                        .GetAwaiter().GetResult();
                    _context.SaveChangesAsync()
                        .GetAwaiter().GetResult();

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
            using (_context)
            {
                try
                {
                    _context.Users.Remove(entity);
                    _context.SaveChanges();

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
            using (_context)
            {
                try
                {
                    return _context.Users.Find(prop);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<User> GetAll(Expression<Func<User, bool>> prop)
        {
            using (_context)
            {
                try
                {
                    return _context.Users.Where(prop).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(User entity)
        {
            using (_context)
            {
                try
                {
                    _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
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
