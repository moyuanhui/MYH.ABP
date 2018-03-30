using System.Collections.Generic;
using MYH.ABP.Roles.Dto;

namespace MYH.ABP.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
