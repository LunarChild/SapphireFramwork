using Sapphire.Common;
using Sapphire.Core.Model.Cms;
using Sapphire.Service.DtoModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Interfaces
{
    public interface ICmsVideoService : IBaseService<CmsVideo>
    {
        Task<ApiResult<Page<CmsVideo>>> GetWherePage(PageParm param);
    }
}
