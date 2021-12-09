using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Bbs;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using SqlSugar;

namespace Sapphire.Service.Implements
{
    /*!
    * 文件名称：Bbs_tags服务接口实现
    */
    public class Bbs_TagsService : BaseService<Bbs_Tags>, IBbs_TagsService
    {
        /// <summary>
        /// 查询所有标签，带数量
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResult<List<TagsDto>>> GetListTagCounts(int page = 8)
        {
            var res = new ApiResult<List<TagsDto>>() { statusCode = (int)ApiEnum.Error };
            try
            {
                res.data=await Db.Queryable<Bbs_Tags>()
                    .Where(s => !s.IsDel)
                    .Select(s => new TagsDto()
                    {
                        Name = s.TagName,
                        EnTagName=s.EnTagName,
                        FirstLetter = s.FirstLetter,
                        TagCount = SqlFunc.Subqueryable<Bbs_Questions>().Where(g => g.Tags.Contains(s.TagName)).Count()
                    })
                    .OrderBy(g => g.TagCount, OrderByType.Desc)
                    .OrderBy(g=>g.EnTagName)
                    .Take(page).ToListAsync();
                res.statusCode = (int)ApiEnum.Status;
            }
            catch (Exception ex)
            {
                res.message = ex.Message;
            }

            return res;
        }
    }
}