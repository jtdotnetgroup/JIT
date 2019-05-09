using Abp.Authorization;
using JIT.Authorization.Roles;
using JIT.Authorization.Users;

namespace JIT.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
