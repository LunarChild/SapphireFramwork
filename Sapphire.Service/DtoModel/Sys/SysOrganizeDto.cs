using System;
using System.Collections.Generic;
using System.Text;

namespace Sapphire.Service.DtoModel
{
    /// <summary>
    /// 组织机构DTO
    /// </summary>
    public class SysOrganizeDto
    {
    }

    public class SysOrganizeTree
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<SysOrganizeTree> children { get; set; }
        public bool spread { get; set; } = true;
    }
}
