using System.Collections.Generic;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Bbs;
using Sapphire.Service.DtoModel;

namespace Sapphire.Service.Interfaces
{
    /*!
    * 文件名称：Bbs_tags服务接口
    */
	public interface IBbs_TagsService: IBaseService<Bbs_Tags>
    {
        /// <summary>
        /// 查询所有标签，带数量
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<List<TagsDto>>> GetListTagCounts(int page=8);
    }
}