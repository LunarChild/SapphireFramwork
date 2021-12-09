using Sapphire.Common;
using Sapphire.Core.Model.Sys;
using Sapphire.Service.DtoModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Interfaces
{
    /// <summary>
    /// 部门管理接口
    /// </summary>
    public interface ISysOrganizeService : IBaseService<SysOrganize>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<Page<SysOrganize>>> GetPagesAsync(PageParm parm);

        /// <summary>
        /// 获得树列表
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<List<SysOrganizeTree>>> GetListTreeAsync();

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<SysOrganize>> GetByGuidAsync(string parm);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<string>> AddAsync(SysOrganize parm);


        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<string>> ModifyAsync(SysOrganize parm);
    }
}
