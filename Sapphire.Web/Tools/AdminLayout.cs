using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sapphire.Web
{
    /// <summary>
    /// 管理后台
    /// </summary>
    public static class AdminLayout
    {
        public static string Pjax(HttpContext httpContext)
        {
            var ispjax = httpContext.Request.Query["_pjax"];
            return !string.IsNullOrEmpty(ispjax) ? "~/Pages/SapphireAdmin/_Layout.cshtml" : "~/Pages/SapphireAdmin/_LayoutMain.cshtml";
        }
        public static string Container(HttpContext httpContext)
        {
            var ispjax = httpContext.Request.Query["_pjax"];
            return ispjax.Contains("content-body")? "content-body" : "container";
        }
    }
}
