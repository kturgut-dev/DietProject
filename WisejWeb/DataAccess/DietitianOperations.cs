using Core.DataAccess;
using Core.Entities.Abstract;
using DietProject.WisejWeb.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace DietProject.WisejWeb.DataAccess
{
    public class DietitianOperations : BaseDataAccess<Dietitian>
    {
        //public DietitianOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }
        //public DietitianOperations() : base(new MigrationsContextFactory()) { }
        public List<Dietitian> GetAllTOPDietitians()
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {
                    return context.Set<Dietitian>()
                          .SqlQuery("exec dbo.spSelectTopDietitians")
                          .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public bool UserIsExists(Int64 UserID)
        {
            return base.Get(x => x.UserID == UserID) != null;
        }

        public List<DietitianViewData> GetAllDietitians(string[] city, int? minPrice, int? maxPrice, int[] stars)
        {
            using (DbContext context = new DietProjectContext())
            {
                try
                {

                    //#if NET48
                    SqlParameter[] parameters =
                    {
                   new SqlParameter("@CityList", SqlDbType.NVarChar)
                    {
                        Value = city.Length == 0 ? null : string.Join(",", city)
                    },
                    new SqlParameter("@MinPrice", SqlDbType.Int)
                    {
                        Value = minPrice ?? 0                     },
                    new SqlParameter("@MaxPrice", SqlDbType.Int)
                    {
                        Value = maxPrice ?? null                     },
                    new SqlParameter("@StarList", SqlDbType.NVarChar)
                    {
                        Value = stars.Length == 0 ? null : string.Join(",", stars),
                        Size = 50
                    } };
                    //#endif

                    return context.Set<DietitianViewData>()
                              .SqlQuery("exec dbo.spSelectDietitianViews @CityList, @MinPrice, @MaxPrice, @StarList",
                             parameters)
                              //.FromSqlRaw("exec dbo.spSelectDietitianViews @cityList, @minPrice, @maxPrice, @starList", parameters)
                              .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

    }
}
