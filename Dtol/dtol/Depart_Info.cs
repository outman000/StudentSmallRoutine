using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public  class Depart_Info
    {

        public int id { get; set; }

        public string DepartName { get; set; }

        public string DepartCode { get; set; }

        public int? Student_InfoId { get; set; }

        public Student_Info Student_Info { get; set; }

        public List<Station_Info> class_Infos { get; set; }
    }
}
