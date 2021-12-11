using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Sys;
using Sapphire.Extensions;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sapphire.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [JwtAuthorize(Roles = "Admin")]
    public class SettingController : ControllerBase
    {
        private readonly ISysAppSettingService _settingService;
        public SettingController(ISysAppSettingService settingService)
        {
            _settingService = settingService;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("getpages")]
        public async Task<IActionResult> GetPages([FromQuery]PageParm parm)
        {
            var res = await _settingService.GetPagesAsync(parm,m=>!m.IsDel,m=>m.UpdateDate,DbOrderEnum.Desc);
            return Ok(new { code = 0, msg = "success", count = res.data.TotalItems, data = res.data.Items });
        }

        /// <summary>
        /// 获得字典栏目Tree列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddRole([FromBody]SysAppSetting parm)
        {
            parm.Guid= Guid.NewGuid().ToString();
            return Ok(await _settingService.AddAsync(parm));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteRole([FromBody]ParmString obj)
        {
            var list = Utils.StrToListString(obj.parm);
            return Ok(await _settingService.UpdateAsync(m => new SysAppSetting() { IsDel = true }, m => list.Contains(m.Guid)));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("edit")]
        public async Task<IActionResult> EditRole([FromBody]SysAppSetting parm)
        {
            return Ok(await _settingService.UpdateAsync(parm));
        }
    }
}