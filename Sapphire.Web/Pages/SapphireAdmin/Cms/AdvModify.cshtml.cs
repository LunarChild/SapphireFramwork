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
    public class AdvModifyModel : PageModel
    {
        private readonly ICmsAdvClassService _classService;
        private readonly ICmsAdvListService _listService;
        public AdvModifyModel(ICmsAdvClassService classService, ICmsAdvListService listService)
        {
            _classService = classService;
            _listService = listService;
        }

        [BindProperty]
        public CmsAdvClass Class { get; set; }

        public CmsAdvList Adv { get; set; }

        public void OnGet(string guid,string column)
        {
            Class = _classService.GetModelAsync(m => m.Guid == column).Result.data;
            Adv = _listService.GetModelAsync(m => m.Guid == guid).Result.data;
        }
    }
}