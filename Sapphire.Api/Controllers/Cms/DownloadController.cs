using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Cms;
using Sapphire.Extensions;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sapphire.Api.Controllers.Cms
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [JwtAuthorize(Roles = "Admin")]
    public class DownloadController : ControllerBase
    {
        private readonly ICmsDownloadService _downloadService;
        public DownloadController(ICmsDownloadService downloadService)
        {
            _downloadService = downloadService;
        }

        #region 文章管理
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("getpages")]
        public IActionResult GetPages([FromQuery]PageParm parm)
        {
            parm.site = SiteTool.CurrentSite?.Guid;
            var res = _downloadService.GetList(parm);
            return Ok(new { code = 0, msg = "success", count = res.TotalItems, data = res.Items });
        }


        /// <summary>
        /// 获得字典栏目Tree列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]CmsDownload parm)
        {
            parm.SiteGuid = SiteTool.CurrentSite?.Guid;
            //处理文件类型
            parm.FileType= FileHelper.GetFileExt(parm.FileUrl);
            return Ok(await _downloadService.AddAsync(parm));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody]ParmString param)
        {
            return Ok(await _downloadService.DeleteAsync(param.parm));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]CmsDownload parm)
        {
            parm.SiteGuid = SiteTool.CurrentSite?.Guid;
            //处理文件类型
            parm.FileType = FileHelper.GetFileExt(parm.FileUrl);
            return Ok(await _downloadService.UpdateAsync(parm));
        }
        #endregion
    }
}