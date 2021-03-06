using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Sys;
using Sapphire.Service.DtoModel;

namespace Sapphire.Service.Interfaces
{
    /// <summary>
    /// 字典分类接口
    /// </summary>
    public interface ISysCodeTypeService : IBaseService<SysCodeType>
    {

        /// <summary>
        /// 获得树列表
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<List<SysCodeTypeTree>>> GetListTreeAsync();

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<SysCodeTypeDto>> GetByGuidAsync(string parm);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<string>> AddAsync(SysCodeType parm);


        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<string>> ModifyAsync(SysCodeType parm);
    }
}
