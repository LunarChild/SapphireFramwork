using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Sapphire.Core.Model.Bbs;
using Sapphire.Core.Model.Member;
using Sapphire.Service.DtoModel;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.Bbs
{
    public class QuestionModel : PageModel
    {
        private readonly IBbs_AnswerService _answerService;
        private readonly IBbs_QuestionsService _questionService;
        public QuestionModel(IBbs_AnswerService answerService,
            IBbs_QuestionsService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        public Bbs_Questions Ask { get; set; }

        public Page<Bbs_Answer> Answer { get; set; }

        public int Order { get; set; } = 0;

        public void OnGet(string number=null,int order=0)
        {
            Order = order;
            Ask = _questionService.GetPageList(new PageParm(){number = number}).Result.data.Items?.FirstOrDefault();
            if (Ask == null) return;
            Ask.LookSum += 1;
            //增加点击数
            _questionService.AddLookSum(Ask);

            Answer = _answerService.GetPageUser(new PageParm() {attr = order, guid = Ask.Guid}).Result.data;
        }
    }
}