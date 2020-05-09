using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
  public  class ExceptStudentSearchMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 年级名称
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }//体温
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 上报时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 个人信息唯一标识
        /// </summary>
         public int? student_InfoId { get; set; }

        /// <summary>
        /// 上传图片的url
        /// </summary>
        public string Url { get; set; }


           public int? facultystaff_InfoId { get; set; }

        public int? UserFiles_InfoId { get; set; }
    }
}
