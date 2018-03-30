using Abp.Authorization;
using MYH.ABP.Authorization.Roles;
using MYH.ABP.Authorization.Users;

namespace MYH.ABP.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
