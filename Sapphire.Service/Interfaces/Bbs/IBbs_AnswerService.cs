using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Bbs;
using Sapphire.Service.DtoModel;

namespace Sapphire.Service.Interfaces
{
    /*!
    * 文件名称：Bbs_answer服务接口
    */
	public interface IBbs_AnswerService: IBaseService<Bbs_Answer>
	{
        /// <summary>
        /// 分页查询问题列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ApiResult<Page<Bbs_Answer>>> GetPageUser(PageParm param);

        /// <summary>
        /// 用户详细里面的回答列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ApiResult<Page<AnswerDto>>> GetUserCenterAnswer(PageParm param);
    }
}