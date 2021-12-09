using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Core.Model.Wx;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.WeChat
{
    [Authorize]
    public class SettingModifyModel : PageModel
    {
        private readonly IWxSettingService _settingService;
        public SettingModifyModel(IWxSettingService settingService)
        {
            _settingService = settingService;
        }

        [BindProperty]
        public WxSetting SettingModel { get; set; }

        public void OnGet(int id)
        {
            SettingModel = _settingService.GetModelAsync(m=>m.Id==id).Result.data;
        }
    }
}