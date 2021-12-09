using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Core.Model.Sys;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Sys
{
    [Authorize]
    public class CodesValModifyModel : PageModel
    {
        private readonly ISysCodeService _sysCodeService;
        public CodesValModifyModel(ISysCodeService sysCodeService)
        {
            _sysCodeService = sysCodeService;
        }

        [BindProperty]
        public SysCode CodeModel { get; set; }
        public void OnGet(string guid)
        {
            CodeModel = _sysCodeService.GetByGuidAsync(guid).Result.data;
            if (string.IsNullOrEmpty(CodeModel.Guid))
            {
                CodeModel.ParentGuid = guid;
            }
        }
    }
}