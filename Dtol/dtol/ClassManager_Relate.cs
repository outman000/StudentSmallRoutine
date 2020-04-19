using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class ClassManager_Relate
    {
        public int id { get; set; }
        public string ClassCode { get; set; }
        public int? Class_InfoId { get; set; }
        public Class_Info Class_Info { get; set; }
        public string IdNumber { get; set; }
        public int? facultystaff_InfoId { get; set; }
        public facultystaff_Info facultystaff_Info { get; set; }

    }
}
