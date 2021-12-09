using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Cms
{
    [Authorize]
    public class DataBaseModel : PageModel
    {
        public string DbSqlPath { get; set; }
        public void OnGet()
        {
            DbSqlPath = FileHelperCore.MapPath("/wwwroot/db_back/") +DateTime.Now.ToString("yyyyMMddHHmmss") + ".sql";
        }
    }
}