using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;

namespace SmallRoutine.Application
{
    public class StudentReportQueries : IStudentReportQueries
    {
        private string _connectionString = string.Empty;

        public StudentReportQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        /// <summary>
        /// 根据查询条件查询学生统计信息
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public List<StudentReportMiddle> GetStudentReportList(StudentStasticSearchViewModel searchModel)
        {
            List<StudentReportMiddle> result = new List<StudentReportMiddle>();

            if (searchModel.GradeName == null || searchModel.GradeName == "")
            {
                var gz = GetStudentListBySearchModel(searchModel, "'10','11','12'", "高中");
                result.AddRange(gz);
                var cz = GetStudentListBySearchModel(searchModel, "'7','8','9'", "初中");
                result.AddRange(cz);
                var xx = GetStudentListBySearchModel(searchModel, "'1','2','3','3','4','5','6'", "小学");
                result.AddRange(xx);
            }

            return result;
        }
        /// <summary>
        /// 根据查询条件查询学生统计信息
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public List<EmployeeReportMiddleModel> GetEmployeeeReportList(StudentStasticSearchViewModel searchModel)
        {
            List<EmployeeReportMiddleModel> result = new List<EmployeeReportMiddleModel>();

            //if (searchModel.GradeName == null || searchModel.GradeName == "")
            //{
            //    var gz = GetEmployeeListBySearchModel(searchModel, "'10','11','12'");
            //    result.AddRange(gz);
            //    var cz = GetEmployeeListBySearchModel(searchModel, "'7','8','9'");
            //    result.AddRange(cz);
            //    var xx = GetEmployeeListBySearchModel(searchModel, "'1','2','3','3','4,'5','6");
            //    result.AddRange(xx);
            //}
            result = GetEmployeeListBySearchModel(searchModel);
            return result;
        }


        private List<EmployeeReportMiddleModel> GetEmployeeListBySearchModel(StudentStasticSearchViewModel searchModel)
        {
            List<EmployeeReportMiddleModel> result = new List<EmployeeReportMiddleModel>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SchoolCode,SchoolName, SUM(ShouldComeSchoolCount) as ShouldComeSchoolCount");
            strSql.Append(",SUM(ActualComeSchoolCount) ActualComeSchoolCount,SUM(ComeSchoolHotCount) ComeSchoolHotCount");
            strSql.Append(",SUM(NotComeSchoolCount) NotComeSchoolCount,SUM(NotComeSchoolByOutCount) NotComeSchoolByOutCount");
            strSql.Append(",SUM(NotComeSchoolByHotCount) NotComeSchoolByHotCount,SUM(NotComeSchoolByOtherCount)  NotComeSchoolByOtherCount ");
            strSql.Append("  from  Template_Employment where 1=1");
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                strSql.Append(" and SchoolCode='" + searchModel.SchoolCode + "'");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            //if (grade != "")
            //    strSql.Append(" and GradeName in(" + grade + ")");
            if (searchModel.Type != null && searchModel.Type != "")
                strSql.Append(" and type='" + searchModel.Type + "'");

            strSql.Append("  Group By SchoolCode,SchoolName");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<EmployeeReportMiddleModel>(strSql.ToString()).ToList();
                connection.Close();
            }

            return result;
        }

        private List<StudentReportMiddle> GetStudentListBySearchModel(StudentStasticSearchViewModel searchModel, string grade, string gradeName)
        {
            List<StudentReportMiddle> result = new List<StudentReportMiddle>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SchoolCode,SchoolName, SUM(ShouldComeSchoolCount) as ShouldComeSchoolCount");
            if (gradeName != "")
            {
                strSql.Append(",'" + gradeName + "' as GradeName ");
            }
            strSql.Append(",SUM(ActualComeSchoolCount) ActualComeSchoolCount,SUM(ComeSchoolHotCount) ComeSchoolHotCount");
            strSql.Append(",SUM(NotComeSchoolCount) NotComeSchoolCount,SUM(NotComeSchoolByOutCount) NotComeSchoolByOutCount");
            strSql.Append(",SUM(NotComeSchoolByHotCount) NotComeSchoolByHotCount,SUM(NotComeSchoolByOtherCount)  NotComeSchoolByOtherCount ");
            strSql.Append("  from  Template_Student where 1=1");
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                strSql.Append(" and SchoolCode='" + searchModel.SchoolCode + "'");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            if (grade != "")
                strSql.Append(" and GradeName in(" + grade + ")");
            if (searchModel.Type != null && searchModel.Type != "")
                strSql.Append(" and type='" + searchModel.Type + "'");

            strSql.Append("  Group By SchoolCode,SchoolName");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<StudentReportMiddle>(strSql.ToString()).ToList();
                connection.Close();
            }

            return result;
        }


        public List<StudentAndEmployeeReportMiddles> GetListBySearchModel(StudentStasticSearchViewModel searchModel)
        {
            List<StudentAndEmployeeReportMiddles> result = new List<StudentAndEmployeeReportMiddles>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select info.* from( ");
            strSql.Append("select SchoolCode,SchoolName, '学生' as Name, SUM(ShouldComeSchoolCount) as ShouldComeSchoolCount");
            strSql.Append(",SUM(ActualComeSchoolCount) ActualComeSchoolCount,SUM(ComeSchoolHotCount) ComeSchoolHotCount");
            strSql.Append(",SUM(NotComeSchoolCount) NotComeSchoolCount,SUM(NotComeSchoolByOutCount) NotComeSchoolByOutCount");
            strSql.Append(",SUM(NotComeSchoolByHotCount) NotComeSchoolByHotCount,SUM(NotComeSchoolByOtherCount)  NotComeSchoolByOtherCount ");
            strSql.Append("  from  Template_Student where 1=1");
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                strSql.Append(" and SchoolCode='" + searchModel.SchoolCode + "'");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.Type != null && searchModel.Type != "")
                strSql.Append(" and type='" + searchModel.Type + "'");

            strSql.Append("  Group By SchoolCode,SchoolName");
            strSql.Append(" union ");
            strSql.Append("select SchoolCode,SchoolName, '教职工' as Name, SUM(ShouldComeSchoolCount) as ShouldComeSchoolCount");
            strSql.Append(",SUM(ActualComeSchoolCount) ActualComeSchoolCount,SUM(ComeSchoolHotCount) ComeSchoolHotCount");
            strSql.Append(",SUM(NotComeSchoolCount) NotComeSchoolCount,SUM(NotComeSchoolByOutCount) NotComeSchoolByOutCount");
            strSql.Append(",SUM(NotComeSchoolByHotCount) NotComeSchoolByHotCount,SUM(NotComeSchoolByOtherCount)  NotComeSchoolByOtherCount ");
            strSql.Append("  from  Template_Employment where 1=1");
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                strSql.Append(" and SchoolCode='" + searchModel.SchoolCode + "'");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.Type != null && searchModel.Type != "")
                strSql.Append(" and type='" + searchModel.Type + "'");

            strSql.Append("  Group By SchoolCode,SchoolName");

            strSql.Append(" ) as info ");
            strSql.Append(" order by info.SchoolCode,info.Name desc");
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<StudentAndEmployeeReportMiddles>(strSql.ToString()).ToList();
                connection.Close();
            }
            foreach (var item in result)
            {
                item.HealthRate = GetHealthRate(searchModel, item.Name, item.SchoolCode) + "%";
            }
            return result;
        }
        private string GetHealthRate(StudentStasticSearchViewModel searchModel, string type, string SchoolCode)
        {
            string healthRate = string.Empty; ;
            if (type == "教职工")
            {
                //StringBuilder sbSelHealth = new StringBuilder();
                //sbSelHealth.Append("select * from Health_Info where 1=1 and CheckType='到校前' and IsComeSchool='是'");
                //if (SchoolCode != null && SchoolCode != "")
                //    sbSelHealth.Append("and facultystaff_InfoId in (select id from facultystaff_Info where SchoolCode='" + SchoolCode + "')");
                //if (searchModel.StartDate != null && searchModel.EndDate != null)
                //    sbSelHealth.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
                //else if (searchModel.StartDate != null && searchModel.EndDate == null)
                //    sbSelHealth.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
                //else if (searchModel.StartDate == null && searchModel.EndDate != null)
                //    sbSelHealth.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
                double healthCount = GetActualFacultystaffCount(searchModel, SchoolCode, "到校前", "");//每日健康数据统计
                //using (var connection = new SqlConnection(_connectionString))
                //{
                //    connection.Open();
                //    var list = connection.Query<HealthEverySearchMiddleModel>(sbSelHealth.ToString()).ToList();
                //    if (list.Count > 0)
                //        healthCount = list.Count;
                //    connection.Close();
                //}
                double studentCount = GetFacultystaffCount(SchoolCode);//应到校教职工数
                if (studentCount != 0)
                {
                    double rate = healthCount / studentCount;
                    healthRate = rate.ToString("f4");
                }
            }
            else
            {
                //StringBuilder sbSelHealth = new StringBuilder();
                //sbSelHealth.Append("select * from Health_Info where 1=1 and IsComeSchool='是'");
                //if (SchoolCode != null && SchoolCode != "")
                //    sbSelHealth.Append("and Student_InfoId in (select id from Student_Info where SchoolCode='" + SchoolCode + "')");
                //if (searchModel.StartDate != null && searchModel.EndDate != null)
                //    sbSelHealth.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
                //else if (searchModel.StartDate != null && searchModel.EndDate == null)
                //    sbSelHealth.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
                //else if (searchModel.StartDate == null && searchModel.EndDate != null)
                //    sbSelHealth.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
                double healthCount = GetActualStudentCount(searchModel, SchoolCode, "", "是");//每日健康数据统计
                //using (var connection = new SqlConnection(_connectionString))
                //{
                //    connection.Open();
                //    var list = connection.Query<HealthEverySearchMiddleModel>(sbSelHealth.ToString()).ToList();
                //    if (list.Count > 0)
                //        healthCount = list.Count;
                //    connection.Close();
                //}
                double studentCount = GetStudenCount(SchoolCode);//应到校学生
                if (studentCount != 0)
                {
                    double rate = healthCount / studentCount;
                    healthRate = rate.ToString("f4");
                }

            }

            return healthRate;
        }

        /// <summary>
        /// 获取应到校教职工数
        /// </summary>
        /// <param name="SchoolCode"></param>
        /// <returns></returns>
        private double GetFacultystaffCount(string SchoolCode)
        {
            StringBuilder sbSelSudent = new StringBuilder();
            sbSelSudent.Append("select * from facultystaff_Info where 1=1");
            if (SchoolCode != null && SchoolCode != "")
                sbSelSudent.Append(" and SchoolCode='" + SchoolCode + "'");
            double studentCount = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<FacultystaffMiddle>(sbSelSudent.ToString()).ToList();
                if (list.Count > 0)
                    studentCount = list.Count;
                connection.Close();
            }
            return studentCount;

        }

        /// <summary>
        /// 获取应到校学生数
        /// </summary>
        /// <param name="SchoolCode"></param>
        /// <returns></returns>
        private double GetStudenCount(string SchoolCode)
        {
            StringBuilder sbSelSudent = new StringBuilder();
            sbSelSudent.Append("select * from Student_Info where SchoolCode='" + SchoolCode + "'");
            double studentCount = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<StudentMiddle>(sbSelSudent.ToString()).ToList();
                if (list.Count > 0)
                    studentCount = list.Count;
                connection.Close();
            }
            return studentCount;
        }

        /// <summary>
        /// 实际到校学生数  健康上报
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="SchoolCode"></param>
        /// <param name="grade">班级</param>
        /// <param name="IsComeSchool">是否到校</param>
        /// <returns></returns>
        private double GetActualStudentCount(StudentStasticSearchViewModel searchModel, string SchoolCode,string grade,string IsComeSchool)
        {
            StringBuilder sbSelHealth = new StringBuilder();
            sbSelHealth.Append("select * from Health_Info where 1=1");
            if (IsComeSchool != null && IsComeSchool != "")
                sbSelHealth.Append("  and IsComeSchool='"+ IsComeSchool + "'");
            if (SchoolCode != null && SchoolCode != "")
            {
                sbSelHealth.Append("and Student_InfoId in (");
                sbSelHealth.Append("select id from Student_Info where SchoolCode='" + SchoolCode + "'");
                if (grade != null && grade != "")
                    sbSelHealth.Append(" and GradeName in(" + grade + ")");
                sbSelHealth.Append(")");
            }
            else
                sbSelHealth.Append("and Student_InfoId is not null");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                sbSelHealth.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                sbSelHealth.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                sbSelHealth.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            double healthCount = 0;//每日健康数据统计
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<HealthEverySearchMiddleModel>(sbSelHealth.ToString()).ToList();
                if (list.Count > 0)
                    healthCount = list.Count;
                connection.Close();
            }
            return healthCount;
        }

        /// <summary>
        /// 实际到校教职工数   健康上报
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="SchoolCode">学校号</param>
        /// <param name="CheckType">到校前、天、早、午、晚类型  </param>
        /// <returns></returns>
        private double GetActualFacultystaffCount(StudentStasticSearchViewModel searchModel, string SchoolCode, string CheckType,string IsComeSchool)
        {
            StringBuilder sbSelHealth = new StringBuilder();
            sbSelHealth.Append("select * from Health_Info where 1=1");
            if (IsComeSchool != null && IsComeSchool != "")
                sbSelHealth.Append(" and IsComeSchool='"+ IsComeSchool + "'");
            if (CheckType != null && CheckType != "")
                sbSelHealth.Append(" and CheckType='" + CheckType + "' ");
            if (SchoolCode != null && SchoolCode != "")
                sbSelHealth.Append("and facultystaff_InfoId in (select id from facultystaff_Info where SchoolCode='" + SchoolCode + "')");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                sbSelHealth.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                sbSelHealth.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                sbSelHealth.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            double healthCount = 0;//每日健康数据统计
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<HealthEverySearchMiddleModel>(sbSelHealth.ToString()).ToList();
                if (list.Count > 0)
                    healthCount = list.Count;
                connection.Close();
            }
            return healthCount;
        }

        /// <summary>
        /// 获取统计图头部数据
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public SchoolAndStudentTopReportMiddleModel GetStudentTopReportMiddleModel(StudentStasticSearchViewModel searchModel)
        {
            SchoolAndStudentTopReportMiddleModel result = new SchoolAndStudentTopReportMiddleModel();
            result.SchoolCount = GetSchoolCount(searchModel.SchoolCode);
            result.StudentCount = Convert.ToInt32(GetStudenCount(searchModel.SchoolCode));
            result.StudentActualCount = Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "","是"));
            result.FacultystaffCount = Convert.ToInt32(GetFacultystaffCount(searchModel.SchoolCode));
            result.FacultystaffActualCount = Convert.ToInt32(GetActualFacultystaffCount(searchModel, searchModel.SchoolCode, searchModel.Type, ""));

            return result;
        }

        /// <summary>
        /// 获取复课学校数量
        /// </summary>
        /// <param name="SchoolCode"></param>
        /// <returns></returns>
        private int GetSchoolCount(string SchoolCode)
        {
            int result = 0;
            string sqlSel = "select * from School_Info where 1=1";
            if (SchoolCode != null && SchoolCode != "")
                sqlSel += " and SchoolCode='" + SchoolCode + "'";
            using (var connection = new SqlConnection(_connectionString))
            {
                var list = connection.Query<dynamic>(sqlSel).ToList();
                if (list.Count != 0)
                    result = list.Count;
            }

            return result;
        }

        public HealthStatisticsMiddleModel GetHealthStatisticsMiddleModel(StudentStasticSearchViewModel searchModel)
        {
            double StudentHealthCount = GetActualStudentCount(searchModel, searchModel.SchoolCode, "", "");
            double FacultystaffHealthCount = GetActualFacultystaffCount(searchModel, searchModel.SchoolCode, searchModel.Type, "");
            HealthStatisticsMiddleModel result = new HealthStatisticsMiddleModel();
            result.StudentHealthCount = Convert.ToInt32(StudentHealthCount);
            result.FacultystaffHealthCount = Convert.ToInt32(FacultystaffHealthCount);
            result.PrimaryCount= Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "'1','2','3','3','4','5','6'", ""));
            result.JuniorCount= Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "'7','8','9'", ""));
            result.HighCount= Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "'10','11','12'", ""));

            double StudentCount = GetStudenCount(searchModel.SchoolCode);
            double studentRate = StudentHealthCount / StudentCount;
            string healthRateStudent = studentRate.ToString("f4");
            result.StudentHealthRate = healthRateStudent;
            double FacultystaffCount = GetFacultystaffCount(searchModel.SchoolCode);
            double FacultystaffRate = FacultystaffHealthCount / FacultystaffCount;
            string healthRateFacultystaff = FacultystaffRate.ToString("f4");
            result.FacultystaffHealthRate = healthRateFacultystaff;
            return result;
        }


        public List<HealthEverySearchMiddleModel> GetHealthEverySearchMiddleModels(HealthEverySearchStatasticViewModel searchModel,string type)
        {
            List<HealthEverySearchMiddleModel> result = new List<HealthEverySearchMiddleModel>();
            if (type == "学生")
            {
                StringBuilder sbSel = new StringBuilder();
                sbSel.Append("select * from Health_Info where  (IsComeSchool = '否') AND (NotComeSchoolReason IS NOT NULL)");
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    sbSel.Append("and Student_InfoId in (select id from Student_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                }
                else
                {
                    sbSel.Append(" and Student_InfoId is not null");
                }
                if (searchModel.StartDate != null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
                else if (searchModel.StartDate != null && searchModel.EndDate == null)
                    sbSel.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
                else if (searchModel.StartDate == null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
                //if (grade != "")
                //    strSql.Append(" and GradeName in(" + grade + ")");
                if (searchModel.CheckType != null && searchModel.CheckType != "")
                    sbSel.Append(" and CheckType='" + searchModel.CheckType + "'");
                sbSel.Append(" order by Createdate desc ");
                sbSel.Append(" offset((" + (searchModel.page.CurrentPageNum + 1) + " - 1) * " + searchModel.page.PageSize + ") rows fetch next " +
                    searchModel.page.PageSize + " rows only ");
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                    connection.Close();
                }
            }
            else
            {
                StringBuilder sbSel = new StringBuilder();
                sbSel.Append("select * from Health_Info where  (IsComeSchool = '否') AND (NotComeSchoolReason IS NOT NULL)");
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    sbSel.Append("and facultystaff_InfoId in (select id from facultystaff_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                }
                else
                {
                    sbSel.Append(" and facultystaff_InfoId is not null");
                }
                if (searchModel.StartDate != null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
                else if (searchModel.StartDate != null && searchModel.EndDate == null)
                    sbSel.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
                else if (searchModel.StartDate == null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
                //if (grade != "")
                //    strSql.Append(" and GradeName in(" + grade + ")");
                if (searchModel.CheckType != null && searchModel.CheckType != "")
                    sbSel.Append(" and CheckType='" + searchModel.CheckType + "'");
                sbSel.Append(" order by Createdate desc ");
                sbSel.Append(" offset((" + (searchModel.page.CurrentPageNum + 1) + " - 1) * " + searchModel.page.PageSize + ") rows fetch next " +
                    searchModel.page.PageSize + " rows only ");

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                    connection.Close();
                }

            }
            return result;
        }

        public int GetHealthEverySearchMiddleModelsTotal(HealthEverySearchStatasticViewModel searchModel, string type)
        {
            List<HealthEverySearchMiddleModel> result = new List<HealthEverySearchMiddleModel>();
            if (type == "学生")
            {
                StringBuilder sbSel = new StringBuilder();
                sbSel.Append("select * from Health_Info where  (IsComeSchool = '否') AND (NotComeSchoolReason IS NOT NULL)");
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    sbSel.Append("and Student_InfoId in (select id from Student_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                }
                else
                {
                    sbSel.Append(" and Student_InfoId is not null");
                }
                if (searchModel.StartDate != null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
                else if (searchModel.StartDate != null && searchModel.EndDate == null)
                    sbSel.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
                else if (searchModel.StartDate == null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
                //if (grade != "")
                //    strSql.Append(" and GradeName in(" + grade + ")");
                if (searchModel.CheckType != null && searchModel.CheckType != "")
                    sbSel.Append(" and CheckType='" + searchModel.CheckType + "'");
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                    connection.Close();
                }
            }
            else
            {
                StringBuilder sbSel = new StringBuilder();
                sbSel.Append("select * from Health_Info where  (IsComeSchool = '否') AND (NotComeSchoolReason IS NOT NULL)");
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    sbSel.Append("and facultystaff_InfoId in (select id from facultystaff_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                }
                else
                {
                    sbSel.Append(" and facultystaff_InfoId is not null");
                }
                if (searchModel.StartDate != null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
                else if (searchModel.StartDate != null && searchModel.EndDate == null)
                    sbSel.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
                else if (searchModel.StartDate == null && searchModel.EndDate != null)
                    sbSel.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
                //if (grade != "")
                //    strSql.Append(" and GradeName in(" + grade + ")");
                if (searchModel.CheckType != null && searchModel.CheckType != "")
                    sbSel.Append(" and CheckType='" + searchModel.CheckType + "'");

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                    connection.Close();
                }

            }
            return result.Count;
        }

        public List<HealthInfoStatasticMiddleModel> GetHealthInfoStatasticMiddles(StudentStasticSearchViewModel searchModel)
        {
            List<HealthInfoStatasticMiddleModel> result = new List<HealthInfoStatasticMiddleModel>();
            StringBuilder sbSel = new StringBuilder();
            sbSel.Append("select info.* from (");
            sbSel.Append("select count(*) CountReason,NotComeSchoolReason as Reason,sc.SchoolName,sc.SchoolCode");
            sbSel.Append(" from Health_Info h  left join Student_Info s on h.Student_InfoId = s.id left join School_Info sc on s.SchoolCode = sc.SchoolCode");
            sbSel.Append(" WHERE(IsComeSchool = '否') AND(NotComeSchoolReason IS NOT NULL) and h.Student_InfoId is not null");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                sbSel.Append(" and  h.CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                sbSel.Append(" and  h.CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                sbSel.Append(" and  h.CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.Type != null && searchModel.Type != "")
                sbSel.Append(" and h.CheckType='" + searchModel.Type + "'");
            sbSel.Append(" group by h.NotComeSchoolReason, sc.SchoolName, sc.SchoolCode");
            sbSel.Append(" union ");
            sbSel.Append("select count(*) CountReason,'到校后发热学' as Reason,sc.SchoolName,sc.SchoolCode");
            sbSel.Append(" from Health_Info h  left join Student_Info s on h.Student_InfoId = s.id left join School_Info sc on s.SchoolCode = sc.SchoolCode");
            sbSel.Append(" WHERE(IsComeSchool = '是') and h.Student_InfoId is not null and cast(Temperature as float) > 37.3");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                sbSel.Append(" and  h.CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                sbSel.Append(" and  h.CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                sbSel.Append(" and  h.CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.Type != null && searchModel.Type != "")
                sbSel.Append(" and h.CheckType='" + searchModel.Type + "'");
            sbSel.Append(" group by sc.SchoolName, sc.SchoolCode");
            sbSel.Append(" union ");
            sbSel.Append(" select count(*) CountReason,'发热未到校' Reason,sc.SchoolName,sc.SchoolCode");
            sbSel.Append(" from Health_Info h left join Student_Info s on h.Student_InfoId = s.id left join School_Info sc on s.SchoolCode = sc.SchoolCode ");
            sbSel.Append(" WHERE(IsComeSchool = '否') AND(NotComeSchoolReason IS NULL) and h.Student_InfoId is not null and cast(Temperature as float) > 37.3");
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                sbSel.Append(" and  h.CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            else if (searchModel.StartDate != null && searchModel.EndDate == null)
                sbSel.Append(" and  h.CreateDate>'" + searchModel.StartDate + "'");
            else if (searchModel.StartDate == null && searchModel.EndDate != null)
                sbSel.Append(" and  h.CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.Type != null && searchModel.Type != "")
                sbSel.Append(" and h.CheckType='" + searchModel.Type + "'");
            sbSel.Append(" group by NotComeSchoolReason, sc.SchoolName, sc.SchoolCode");
            sbSel.Append(") as info where 1 = 1");
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                sbSel.Append(" and info.SchoolCode='" + searchModel.SchoolCode + "'");
            sbSel.Append(" order by info.SchoolName");
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<HealthInfoStatasticMiddleModel>(sbSel.ToString()).ToList();
                connection.Close();
            }
            return result;
        }

    }
}
