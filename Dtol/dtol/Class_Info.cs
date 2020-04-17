using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Class_Info
    {
        public int id { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public int? Grade_InfoId { get; set; }
        public Grade_Info Grade_Info { get; set; }


      //  public List<ClassManager_Relate> classManager_Relates { get; set; }

        public List<Student_Info> Student_Info { get; set; }
    }
    
}
