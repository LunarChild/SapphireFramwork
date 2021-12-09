using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sapphire.Extensions
{
    /// <summary>
    /// 新增一个社区用户的认证策略
    /// </summary>
    public class BbsUserAuthorizeAttribute : AuthorizeAttribute
    {
        public const string BbsUserAuthenticationScheme = "BbsUserAuthenticationScheme";

        public BbsUserAuthorizeAttribute()
        {
            this.AuthenticationSchemes = BbsUserAuthenticationScheme;
        }
    }
}
