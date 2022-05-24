using Core.DataAccess;
using DietProject.WisejWeb.Entities;
using System;

namespace DietProject.WisejWeb.DataAccess
{
    public class CustomerOperations : BaseDataAccess<Customer>
    {
        //public CustomerOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) {}
        //public CustomerOperations() : base(new MigrationsContextFactory()) { }

        public bool UserIsExists(Int64 UserID)
        {
            return base.Get(x => x.UserID == UserID) != null;
        }

    }
}
