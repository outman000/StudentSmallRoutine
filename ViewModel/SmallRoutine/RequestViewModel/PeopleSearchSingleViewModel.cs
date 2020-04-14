using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel
{
   public class PeopleSearchSingleViewModel
    {
        /// <summary>
        /// 责任部门
        /// </summary>
        public string ResponsibleDepartment { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PeopleName { get; set; }
        /// <summary>
        /// 是否湖北籍贯
        /// </summary>
        public string IsHubeiOrigin { get; set; }
        /// <summary>
        /// 详细情况
        /// </summary>
        public string DetailSituation { get; set; }
        /// <summary>
        /// 三十日内是否途经湖北
        /// </summary>
        public string IsPassHubei { get; set; }
        /// <summary>
        /// 搭乘过的途经湖北航班火车汽车牌照
        /// </summary>
        public string HuBeiLicence { get; set; }
        /// <summary>
        /// 离津日期
        /// </summary>
        public DateTime? LeaveJinDate { get; set; }
        /// <summary>
        /// 返津日期
        /// </summary>
        public DateTime? BackJinLDate { get; set; }
        /// <summary>
        /// 目前是否在开发区
        /// </summary>
        public string IsInZone { get; set; }
        /// <summary>
        /// 现住址
        /// </summary>
        public string NowAddress { get; set; }
        /// <summary>
        /// 是否发烧
        /// </summary>
        public string IsHot { get; set; }
        /// <summary>
        /// 备注情况
        /// </summary>
        public string RemarkSituation { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string National { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string Duties { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDnumber { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string ContactMethod { get; set; }
        /// <summary>
        /// 所属网格部门
        /// </summary>
        public string Griddepartment { get; set; }
        /// <summary>
        /// 所属网格编号
        /// </summary>
        public string GriddepartmentNum { get; set; }
        /// <summary>
        /// 所属行业部门
        /// </summary>
        public string IndustrySector { get; set; }
        /// <summary>
        /// 回津状况（未离开，外地回津等）
        /// </summary>
        public string backJinInformation { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        ///是否隔离
        /// </summary>
        public string isIsolation { get; set; }

        PeopleSearchSingleViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
