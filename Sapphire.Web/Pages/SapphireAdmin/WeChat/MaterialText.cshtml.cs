using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.WeChat
{
    [Authorize]
    public class MaterialTextModel : PageModel
    {
        public int WxId { get; set; } = 0;
        public int Id { get; set; } = 0;
        public void OnGet(int wxid,int id)
        {
            WxId = wxid;
            Id = id;
        }
    }
}