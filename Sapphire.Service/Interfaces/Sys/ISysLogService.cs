using System;
using Sapphire.Common;
using Sapphire.Core.Model.Sys;
using Sapphire.Service.DtoModel;
using System.Threading.Tasks;

namespace Sapphire.Service.Interfaces
{
    /// <summary>
    /// 系统日志业务接口
    /// </summary>
    public interface ISysLogService : IBaseService<SysLog>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<Page<SysLog>>> GetPagesAsync(PageParm parm);
        
    }
}
