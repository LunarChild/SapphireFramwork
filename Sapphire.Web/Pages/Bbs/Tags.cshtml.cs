using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Bbs;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.Bbs
{
    public class TagsModel : PageModel
    {
        private readonly IBbs_TagsService _tagService;
        public TagsModel(IBbs_TagsService tagService)
        {
            _tagService = tagService;
        }

        public List<TagsDto> TagList { get; set; }

        public void OnGet()
        {
            TagList = _tagService.GetListTagCounts(100).Result.data;
        }
    }
}