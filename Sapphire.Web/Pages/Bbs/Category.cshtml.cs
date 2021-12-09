using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Bbs;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.Bbs
{
    public class CategoryModel : PageModel
    {
        private readonly IBbs_ClassifyService _classifyService;
        public CategoryModel(IBbs_ClassifyService classifyService)
        {
            _classifyService = classifyService;
        }

        public List<Bbs_Classify> CategoryList { get; set; }

        public void OnGet()
        {
            CategoryList = _classifyService.GetListAsync(m => !m.IsDel, m => m.FirstLetter, DbOrderEnum.Desc).Result.data;
        }
    }
}