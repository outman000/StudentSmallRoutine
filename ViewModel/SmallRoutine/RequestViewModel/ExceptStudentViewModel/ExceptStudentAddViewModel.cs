using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel
{
    public class ExceptStudentAddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? student_InfoId { get; set; }
    }
}
