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
    public class RoleMenuController : ControllerBase
    {
        private readonly ISysPermissionsService _roleMenu;
        public RoleMenuController(ISysPermissionsService roleMenu)
        {
            _roleMenu = roleMenu;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetPages([FromQuery]PageParm param)
        {
            var res = await _roleMenu.GetListAsync(param.key);
            return Ok(new { code = 0, msg = "success", count = 100, res.data });
        }

        /// <summary>
        /// 角色授权菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("add"), ApiAuthorize(Modules = "Role", Methods = "Authorize", LogType = LogEnum.AUTHORIZE)]
        public async Task<IActionResult> SaveRoleMenu([FromBody]SysPermissions parm)
        {
            return Ok(await _roleMenu.SaveAsync(parm));
        }

        /// <summary>
        /// 角色授权菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("add/authorization"), ApiAuthorize(Modules = "Role", Methods = "Authorize", LogType = LogEnum.AUTHORIZE)]
        public IActionResult SaveAuthorization([FromBody]SysMenuAuthorization parm)
        {
            return Ok(_roleMenu.SaveAuthorization(parm.list, parm.roleGuid));
        }

        /// <summary>
        /// 用户授权角色
        /// </summary>ApiAuthorize(Modules = "Admin", Methods = "Authorize", LogType = LogEnum.AUTHORIZE)
        /// <returns></returns>
        [HttpPost("torole")]
        public async Task<IActionResult> AdminToRole([FromBody]SysPermissions parm)
        {
            return Ok(await _roleMenu.ToRoleAsync(parm, parm.status));
        }

        /// <summary>
        /// 菜单授权-菜单功能
        /// </summary>
        /// <returns></returns>
        [HttpPost("tubtnfun"), ApiAuthorize(Modules = "Role", Methods = "Authorize", LogType = LogEnum.AUTHORIZE)]
        public IActionResult RoleMenuToFun([FromBody]SysPermissionsParm parm)
        {
            return Ok(_roleMenu.RoleMenuToFunAsync(parm));
        }
    }
}