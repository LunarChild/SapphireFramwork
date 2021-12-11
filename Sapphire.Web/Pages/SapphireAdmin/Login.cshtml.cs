using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Sys;
using Sapphire.Extensions;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Sapphire.Web.Pages.SapphireAdmin
{
    
    public class LoginModel : PageModel
    {
        [BindProperty]
        public List<string> RsaKey { get; set; }

        /// <summary>
        /// 增加一个随机数保障浏览器和刷新导致密钥丢失问题
        /// </summary>
        public string Number { get; set; }
        public void OnGet()
        {            
            var auth = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //auth.Result.Succeeded;
            if (auth.Status.ToString()!= "Faulted")
            {
                RedirectToPage("/SapphireAdmin/Index");
            }
            Number = Utils.Number(15);
            RsaKey = RSACrypt.GetKey();
            //获得公钥和私钥
            MemoryCacheService.Default.SetCache("LOGINKEY_"+Number, RsaKey,10);
        }

    }
}