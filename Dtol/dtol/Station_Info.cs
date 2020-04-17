using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    //岗位
    public class Station_Info
    {
        public int id { get; set; }
        public string StaffName { get; set; }
        public string StaffCode { get; set; }
        public int? Depart_InfoId { get; set; }
        public Depart_Info Depart_Info { get; set; }
    }
}
