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
    public class TemplateModifyModel : PageModel
    {
        private readonly ICmsTemplateService _tempService;
        public TemplateModifyModel(ICmsTemplateService tempService)
        {
            _tempService = tempService;
        }

        [BindProperty]
        public CmsTemplate Template { get; set; }

        public void OnGet(int id=0)
        {
            Template = _tempService.GetModelAsync(m=>m.Id==id).Result.data;
        }
    }
}