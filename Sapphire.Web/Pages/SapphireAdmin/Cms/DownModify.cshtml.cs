using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Core.Model.Cms;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Cms
{
    [Authorize]
    public class DownModifyModel : PageModel
    {
        private readonly ICmsDownloadService _downservice;
        public DownModifyModel(ICmsDownloadService downservice)
        {
            _downservice = downservice;
        }

        [BindProperty]
        public CmsDownload Download { get; set; }


        public void OnGet(int id = 0, int column = 0)
        {
            Download = _downservice.GetModelAsync(m => m.Id == id).Result.data;
            if (Download.Id == 0 && column != 0)
            {
                Download.ColumnId = column;
            }
         
        }
    }
}