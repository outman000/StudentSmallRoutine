using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel
{
    public class DayAndNightDefaultSearchViewModel
    {
        /// <summary>
        /// 教师唯一主键
        /// </summary>
        public int userKey { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年纪编号
        /// </summary>
        public string GradeCode{ get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public string ClassCode { get; set; }
        /// <summary>
        /// 时段
        /// </summary>
        public string AddTimeInterval { get; set; }

        /// <summary>
        /// 填报时间
        /// </summary>
        public DateTime? addCreatedate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        DayAndNightDefaultSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
