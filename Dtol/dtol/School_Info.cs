using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public  class School_Info
    {
        public int id { get; set; }
        
        public string SchoolName { get; set; }

        public string SchoolCode { get; set; }


   
        public List<Station_Info> class_Infos { get; set; }
    }
}
