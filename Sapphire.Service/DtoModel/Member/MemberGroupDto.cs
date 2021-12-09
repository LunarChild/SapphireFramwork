using Sapphire.Core.Model.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sapphire.Service.DtoModel
{
    public class MemberGroupDto
    {
        public Member member { get; set; }

        public List<Member_Group> group { get; set; }
    }
}
