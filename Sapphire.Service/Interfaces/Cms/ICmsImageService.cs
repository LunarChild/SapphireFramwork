using Sapphire.Common;
using Sapphire.Core.Model.Cms;
using Sapphire.Extensions;
using Sapphire.Service.DtoModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapphire.Service.Interfaces
{
    /// <summary>
    /// 图片管理业务接口
    /// </summary>
    public interface ICmsImageService : IBaseService<CmsImage>
    {
        CloudFile GetList(PageParm parm);
    }
}
