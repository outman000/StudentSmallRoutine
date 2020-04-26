using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel
{
    public class ExceptStudentUpdateViewModel
    {
        /// <summary>
        /// 主键id
        /// 
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 登陆人的唯一id
        /// </summary>

        public int? student_InfoId { get; set; }
    }
}
