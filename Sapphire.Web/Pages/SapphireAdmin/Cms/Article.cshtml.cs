using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Cms;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Cms
{
    [Authorize]
    public class ArticleModel : PageModel
    {
        private readonly ICmsColumnService _columnService;
        public ArticleModel(ICmsColumnService columnService)
        {
            _columnService = columnService;
        }


        public List<CmsColumn> ColumnList { get; set; }
        public int ColumnId { get; set; }

        public void OnGet(int id = 0, int column = 0)
        {
            ColumnId = column;
            var list = _columnService.RecursiveModule(_columnService.GetListAsync().Result.data);
            foreach (var item in list)
            {
                item.Title = Utils.LevelName(item.Title, item.ClassLayer);
            }
            ColumnList = list;
        }
    }
}