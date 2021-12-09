using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Core.Model.Sys;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Sys
{
    [Authorize]
    public class CodesModifyModel : PageModel
    {
        private readonly ISysCodeTypeService _sysCodeTypeService;
        public CodesModifyModel(ISysCodeTypeService sysCodeTypeService)
        {
            _sysCodeTypeService = sysCodeTypeService;
        }

        [BindProperty]
        public SysCodeTypeDto CodeType { get; set; }

        [BindProperty]
        public List<SysCodeType> SelectList { get; private set; }

        public void OnGet(string guid)
        {
            CodeType = _sysCodeTypeService.GetByGuidAsync(guid).Result.data;
            //获得列表
            SelectList = _sysCodeTypeService.GetListAsync().Result.data;
        }

    }
}