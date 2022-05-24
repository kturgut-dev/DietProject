using Core.DataAccess;
using DietProject.WisejWeb.Entities;

namespace DietProject.WisejWeb.DataAccess
{
    public class UserOperations : BaseDataAccess<User>
    {
        //public UserOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }
        //public UserOperations() : base(new MigrationsContextFactory()) { }
        public User Login(string email, string hashedPass)
        {
            return base.Get(x => x.EPosta == email && x.Password == hashedPass);
        }

    }
}
