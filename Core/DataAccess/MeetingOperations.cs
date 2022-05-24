using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietProject.Core.DataAccess
{
    public class MeetingOperations : BaseDataAccess<Meeting>
    {
        public MeetingOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }
        public MeetingOperations() : base(new MigrationsContextFactory()) { }
    }
}
