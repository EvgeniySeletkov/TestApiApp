using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Identity;

namespace TestApiApp.Extensions
{
    public static class IdentityErrorExtension
    {
        public static InfoMessage ToInfoMessage(this IdentityError error)
        {
            return new InfoMessage
            {
                Title = error.Code,
                MessageText = error.Description,
            };
        }

        public static ErrorInfo ToErrorInfo(this IdentityError error)
        {
            return new ErrorInfo
            {
                Key = error.Code,
                ErrorMessage = error.Description,
            };
        }
    }
}
