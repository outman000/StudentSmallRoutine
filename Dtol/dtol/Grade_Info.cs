using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Grade_Info
    {
        public int id { get; set; }
        public string GradeName { get; set; }
        public string GradeCode { get; set; }
        public int? Station_InfoId { get; set; }
        public Station_Info Station_Info { get; set; }
        public List<Class_Info> class_Infos { get; set; }
    }
}
