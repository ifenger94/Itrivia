using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITrivia.Helpers
{
    public static class LanguageHelper
    {
        public static string CurrentLanguage(HttpRequest request)
        {
            StringValues value;
            
            if (request.Headers.TryGetValue("language", out value))
            {
                return value.ToString();
            }
            
            return "es";
        }
    }
}
