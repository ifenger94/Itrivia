using Microsoft.Extensions.Primitives;

namespace Itrivia.WebApi.Helpers
{
    public static class JwtManagmentHelper
    {
        public static string RetrieveAuthorizationFromHeader(HttpRequest request)
        {
            StringValues value;

            if (request.Headers.TryGetValue("Authorization", out value))
            {
                return value.ToString().Replace("Bearer ","");
            }

            return String.Empty;
        }


        public static string GetCurrentUser(HttpRequest request)
        {
            string username = request.HttpContext.User.Identity.Name;
            username = username.ToLower();
            if (string.IsNullOrEmpty(username)) username = "USR_ANONYMOUS";
            return username;
        }
    }
}
