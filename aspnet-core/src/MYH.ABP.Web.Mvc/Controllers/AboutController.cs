using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MYH.ABP.Controllers;

namespace MYH.ABP.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ABPControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
