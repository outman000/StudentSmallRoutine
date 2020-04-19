using Dtol.Attribute;
using System;
using System.Collections.Generic;
using System.Text;
namespace Dtol.dtol
{
    public class ReadLog
    {
        public int id { get; set; }
        [ExcelAttribute("openid")]
        public string openid { get; set; }
        [ExcelAttribute("创建时间")]
        public DateTime CreateDate { get; set; }
 
    }
}
