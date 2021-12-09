using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Cms
{
    public class VideoModel : PageModel
    {
        public int ColumnId { get; set; } = 0;

        public void OnGet(int column = 0)
        {
            ColumnId = column;
        }
    }
}
