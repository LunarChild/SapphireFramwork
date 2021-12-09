using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Bbs;
using Sapphire.Extensions;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Sapphire.Web.Pages.Bbs
{
    [BbsUserAuthorize]
    public class AskQuestionModel : PageModel
    {
        private readonly IBbs_ClassifyService _classifyService;
        private readonly IBbs_TagsService _tagService;
        public AskQuestionModel(IBbs_ClassifyService classifyService
        , IBbs_TagsService tagService)
        {
            _classifyService = classifyService;
            _tagService = tagService;
        }

        public List<Bbs_Classify> classifyList { get; set; }

        public string TagStr { get; set; }

        public void OnGet()
        {
            classifyList = _classifyService.GetListAsync(m => !m.IsDel, m => m.FirstLetter, DbOrderEnum.Asc).Result.data;

            var tagList = _tagService.GetListAsync().Result.data;
            if (tagList.Any())
            {
                TagStr = JsonConvert.SerializeObject(tagList.Select(m => new TagsDto(){Name = m.TagName,FirstLetter = m.FirstLetter}));
            }
        }
    }
}