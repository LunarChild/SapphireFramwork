using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Core.Model.Sys;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sapphire.Common;

namespace Sapphire.Web.Pages.SapphireAdmin.Sys
{
    [Authorize]
    public class AdminModifyModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}