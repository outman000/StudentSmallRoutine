using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Info
    {
        public int id { set; get; }
        public string Idnumber { get; set; }
        public string password { get; set ; } 
        public DateTime? CreateDate { get; set; }

    }
}
