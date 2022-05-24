using Core.Entities;
using DietProject.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class MeasureUnitsOperations : BaseDataAccess<MeasureUnit>
    {
        public MeasureUnitsOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }
        public MeasureUnitsOperations() : base(new MigrationsContextFactory()) { }
    }
}
