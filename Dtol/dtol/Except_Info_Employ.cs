using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Except_Info_Employ
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Idnumber { get; set; }
        public string Content { get; set; }

        public string Temperature { get; set; }//体温
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public int? facultystaff_InfoId { get; set; }
        public facultystaff_Info  facultystaff_Info { get; set; }

        public int? UserFiles_InfoId { get; set; }
        public UserFiles_Info UserFiles_Info { get; set; }
    }
}
