using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Core.Model.Cms;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Cms
{
    public class VideoModifyModel : PageModel
    {
        private readonly ICmsVideoService _videoService;
        public VideoModifyModel(ICmsVideoService videoService)
        {
            _videoService = videoService;
        }

        [BindProperty]
        public CmsVideo Video { get; set; }


        public void OnGet(int id = 0, int column = 0)
        {
            Video = _videoService.GetModelAsync(m => m.Id == id).Result.data;
            if (Video.Id == 0 && column != 0)
            {
                Video.ParentId = column;
            }

        }
    }
}
