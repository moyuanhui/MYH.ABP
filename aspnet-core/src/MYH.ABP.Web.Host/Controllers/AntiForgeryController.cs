using Microsoft.AspNetCore.Antiforgery;
using MYH.ABP.Controllers;

namespace MYH.ABP.Web.Host.Controllers
{
    public class AntiForgeryController : ABPControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
