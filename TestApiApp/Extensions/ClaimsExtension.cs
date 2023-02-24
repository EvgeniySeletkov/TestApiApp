using System.Security.Claims;

namespace TestApiApp.Extensions
{
    public static class ClaimsExtension
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim is null)
            {
                throw new ArgumentNullException(nameof(claim), "Not found.");
            }

            return claim.Value;
        }
    }
}
