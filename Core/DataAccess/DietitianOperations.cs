using Core.DataAccess;
using Core.Entities.Abstract;
using DietProject.Core.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DietProject.Core.DataAccess
{
    public class DietitianOperations : BaseDataAccess<Dietitian>
    {
        public DietitianOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }

        public bool UserIsExists(Int64 UserID)
        {
            return base.Get(x => x.UserID == UserID) != null;
        }

        public List<DietitianViewData> GetAllDietitians(string[] city, int? minPrice, int? maxPrice, int[] stars)
        {
            using (DbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    SqlParameter[] parameters =
                    {
                   new SqlParameter("@CityList", SqlDbType.NVarChar)
                    {
                        Value = city.Length == 0 ? DBNull.Value : string.Join(",", city)
                    },
                    new SqlParameter("@MinPrice", SqlDbType.Int)
                    {
                        Value = !minPrice.HasValue ? 0 : minPrice.Value
                    },
                    new SqlParameter("@MaxPrice", SqlDbType.Int)
                    {
                        Value = !maxPrice.HasValue ? DBNull.Value : maxPrice.Value
                    },
                    new SqlParameter("@StarList", SqlDbType.NVarChar)
                    {
                        Value = stars.Length == 0 ? DBNull.Value : string.Join(",", stars),
                        Size = 50
                    } };


                    return context.Set<DietitianViewData>()
                              .FromSqlRaw("exec dbo.spSelectDietitianViews @CityList, @MinPrice, @MaxPrice, @StarList",
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
