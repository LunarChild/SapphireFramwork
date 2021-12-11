using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Common;
using Microsoft.AspNetCore.Mvc;

namespace Sapphire.WebApi.Controllers.Tasks
{
    [Route("api/job/test")]
    [ApiController]
    public class TestJobController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Logger.Default.Info("任务调度："+DateTime.Now);
            return new string[] { "value1", "value2" };
        }

    }
}
