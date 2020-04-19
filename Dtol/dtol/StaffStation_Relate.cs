using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class StaffStation_Relate
    {
        public int id { get; set; }

        public string StaffCode { get; set; }
        public int? Station_InfoId { get; set; }
        public Station_Info Station_Info { get; set; }
        public string IdNumber { get; set; }
        public int? facultystaff_InfoId { get; set; }
        public facultystaff_Info facultystaff_Info { get; set; }
    }
}
