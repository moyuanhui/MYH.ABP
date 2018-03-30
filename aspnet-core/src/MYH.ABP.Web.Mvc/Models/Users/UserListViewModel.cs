using System.Collections.Generic;
using MYH.ABP.Roles.Dto;
using MYH.ABP.Users.Dto;

namespace MYH.ABP.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
