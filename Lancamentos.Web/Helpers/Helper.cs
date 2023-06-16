using System.Security.Claims;

namespace Lancamentos.Web.Helpers
{
    public static class Helper
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?? "";
        }
    }
}
