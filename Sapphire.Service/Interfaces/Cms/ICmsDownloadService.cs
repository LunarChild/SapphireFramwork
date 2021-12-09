using Sapphire.Common;
using Sapphire.Core.Model.Cms;
using Sapphire.Service.DtoModel;

namespace Sapphire.Service.Interfaces
{
    /*!
    * 文件名称：CmsDownload服务接口
    * 版权所有：北京飞易腾科技有限公司
    * 企业官网：http://www.feiyit.com
    */
	public interface ICmsDownloadService: IBaseService<CmsDownload>
	{
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="parm">CmsColumn</param>
        /// <returns></returns>
        Page<CmsDownload> GetList(PageParm parm);
    }
}