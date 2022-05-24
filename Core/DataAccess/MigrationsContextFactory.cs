using DietProject.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    //https://www.c-sharpcorner.com/article/simulating-code-first-with-entity-framework-core/
    public class MigrationsContextFactory : IDbContextFactory<DietProjectContext> //otomatikcontext olusturma
    {
        public DietProjectContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DietProjectContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=DietSystem;Trusted_Connection=True;TrustServerCertificate=True");

            return new DietProjectContext(optionsBuilder.Options);
        }
    }
}
