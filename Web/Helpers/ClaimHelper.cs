using DietProject.Core.DataAccess;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Web.Models;

namespace Web.Helpers
{
    public static class ClaimHelper
    {
        public static IIdentity? UserIdentity { get; private set; }

        public static void SetUserIdentity(IIdentity? _UserIdentity)
        {
            UserIdentity = _UserIdentity;
        }

        public static bool IsAdmin => (UserIdentity as ClaimsIdentity).Claims.First(x => x.Type == nameof(IsAdmin)).Value == "True" ? true : false;
        public static Int64 UserID => Convert.ToInt64((UserIdentity as ClaimsIdentity).Claims.First(x => x.Type == nameof(UserID)).Value);
        public static string EPosta => (UserIdentity as ClaimsIdentity).Claims.First(x => x.Type == nameof(EPosta)).Value;
        public static string FullName => (UserIdentity as ClaimsIdentity).Claims.First(x => x.Type == nameof(FullName)).Value;

        public static UserTypes GetUserType(Int64? UserID = null)
        {
            DietitianOperations usOp = new DietitianOperations();
            Int64 _userID = (UserID.HasValue && UserID.Value > 0) ? UserID.Value : ClaimHelper.UserID;
            if (usOp.Get(x => x.UserID == _userID) != null)
            {
                return UserTypes.Dietitian;
            }

            CustomerOperations cusOp = new CustomerOperations();
            if (cusOp.Get(x => x.UserID == _userID) != null)
            {
                return UserTypes.Customer;
            }

            return UserTypes.NoActivated;
        }

    }
}
