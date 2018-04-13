using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using MYH.ABP.Authorization;
using MYH.ABP.Controllers;
using MYH.ABP.Users;
using MYH.ABP.Web.Models.Users;
using Abp.Runtime.Caching;

namespace MYH.ABP.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ABPControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ICacheManager _cacheManager;

        public UsersController(IUserAppService userAppService,ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            
            var users = (await _userAppService.GetAll(new PagedResultRequestDto {MaxResultCount = int.MaxValue})).Items; // Paging not implemented yet
            //_cacheManager.GetCache("fadf").Set("username:001","test");
            //var aa = _cacheManager.GetCache("fadf").GetOrDefault("username:001");
            var model = new UserListViewModel
            {
                Users = users,
               // Roles = roles
            };
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
    }
}
