using Microsoft.AspNetCore.Antiforgery;
using JIT.Controllers;

namespace JIT.Web.Host.Controllers
{
    public class AntiForgeryController : JITControllerBase
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
