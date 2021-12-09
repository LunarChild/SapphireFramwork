using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Sapphire.Core.Model.Sys;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ISysMenuService _sysMenuService;
        public IndexModel(ISysMenuService sysMenuService)
        {
            _sysMenuService = sysMenuService;
        }
        [BindProperty]
        public List<SysMenu> list { get; set; }
        [BindProperty]
        public string adminGuid { get; set; }
        public void OnGet()
        {
            list = _sysMenuService.GetPagesAsync(new Service.DtoModel.PageParm() { limit = 1000 }).Result.data.Items;
            adminGuid = User.Identities.First(u => u.IsAuthenticated).FindFirst(ClaimTypes.Sid).Value;
        }
    }
}