using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Sapphire.Web.Pages.SapphireAdmin.Sys
{
    [Authorize]
    public class MenuModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}