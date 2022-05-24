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
    public class UserOperations : BaseDataAccess<User>
    {
        public UserOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }
        public UserOperations() : base(new MigrationsContextFactory()) { }
        public User Login(string email, string hashedPass)
        {
            return base.Get(x => x.EPosta == email && x.Password == hashedPass);
        }

    }
}
