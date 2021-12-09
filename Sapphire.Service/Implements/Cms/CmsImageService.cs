using Sapphire.Service.Extensions;
using Sapphire.Common;
using Sapphire.Core;
using Sapphire.Core.Model.Cms;
using Sapphire.Extensions;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Implements
{
    public class CmsImageService  : BaseService<CmsImage>, ICmsImageService
    {
        public CloudFile GetList(PageParm parm)
        {
            var model = new CloudFile() { Code = 200};
            try
            {
                var query = Db.Queryable<CmsImage>()
                        .WhereIF(parm.where!="/",m=>m.ImgBig.Contains(parm.where))
                        .OrderBy(m=>m.AddDate,OrderByType.Desc)
                        .ToPageAsync(parm.page, parm.limit);
                var fileList = new List<ListInfo>();
                if (query.Result.TotalItems != 0)
                {
                    foreach (var item in query.Result.Items)
                    {
                        fileList.Add(new ListInfo()
                        {
                            Name = item.ImgBig,
                            Size = item.ImgSize,
                            Type = item.ImgType,
                            Time = item.AddDate
                        });
                    }
                }
                model.list = fileList;
            }
            catch (Exception ex)
            {
                model.Message = ApiEnum.Error.GetEnumText() + ex.Message;
                model.Code = (int)ApiEnum.Error;
            }
            return model;
        }
    }
}
