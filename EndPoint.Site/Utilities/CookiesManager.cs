using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Utilities
{
    public  class CookiesManager
    {
        private  CookieOptions getCookieOptions(HttpContext context)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                Expires = DateTime.Now.AddDays(100),
            };
        }
        public  void Add(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value, getCookieOptions(context));
        }

        public  void Delete(HttpContext context, string token)
        {
            if (context.Request.Cookies.ContainsKey(token))
            {
                context.Response.Cookies.Delete(token);
            }

        }

        public  bool Contains(HttpContext context, string token)
        {
            return context.Request.Cookies.ContainsKey(token);
        }

        public  Guid GetBrowserID(HttpContext context)
        {
            string browserId = GetValue(context, "BowserId");
            if (browserId == null)
            {
                string value = Guid.NewGuid().ToString();
                Add(context, "BowserId", value);
                browserId = value;
            }
            Guid guidBowser;
            Guid.TryParse(browserId, out guidBowser);
            return guidBowser;
        }

        private  string GetValue(HttpContext context, string token)
        {
            string cookieValue;

            if (!context.Request.Cookies.TryGetValue(token,out cookieValue))
            {
                return null;
            }
            return cookieValue;
        }
    }
}
