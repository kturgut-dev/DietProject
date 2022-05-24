using DietProject.WisejWeb.DataAccess;
using DietProject.WisejWeb.Entities;
using DietProject.WisejWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public class BaseDataAccess<TEntity> : IBaseOperations<TEntity> where TEntity : BaseEntity, new()
    {
        //public readonly IDbContextFactory<DietProjectContext> _contextFactory;

        //public BaseDataAccess(IDbContextFactory<DietProjectContext> blogContext)
        //{
        //    _contextFactory = blogContext;
        //}
        public bool Add(TEntity entity)
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {
                    context.Entry(entity).State = EntityState.Added;
                    context.SaveChangesAsync().GetAwaiter().GetResult();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool Delete(TEntity entity)
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChangesAsync().GetAwaiter().GetResult();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> prop)
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {
                    if (prop == null)
                        throw new ArgumentNullException("expression");

                    return context.Set<TEntity>()
                        .FirstOrDefaultAsync(prop)
                        .GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> prop = null)
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {
                    
                    return prop==null ? context.Set<TEntity>().ToListAsync().GetAwaiter().GetResult()
                        : context.Set<TEntity>().Where(prop)
                            .ToListAsync().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public bool Update(TEntity entity)
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChangesAsync().GetAwaiter().GetResult();
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
