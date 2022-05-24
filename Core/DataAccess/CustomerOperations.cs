using DietProject.Core.Entities;
using DietProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DietProject.Core.DataAccess
{
    public class CustomerOperations : BaseDataAccess<Customer>
    {
        public CustomerOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) {}
        public CustomerOperations() : base(new MigrationsContextFactory()) { }

        public bool UserIsExists(Int64 UserID)
        {
            return base.Get(x => x.UserID == UserID) != null;
        }

    }
}
