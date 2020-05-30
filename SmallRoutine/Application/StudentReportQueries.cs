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
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            //if (grade != "")
            //    strSql.Append(" and GradeName in(" + grade + ")");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }
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
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }

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
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }

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
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    strSql.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    strSql.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                strSql.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }

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
                double healthCount = GetActualFacultystaffCount(searchModel, SchoolCode, "到校前", "", "");//每日健康数据统计
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
                double healthCount = GetActualStudentCount(searchModel, SchoolCode, "", "是", "");//每日健康数据统计
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
            sbSelSudent.Append("select * from Student_Info where 1=1");
            if (SchoolCode != "")
                sbSelSudent.Append(" and  SchoolCode='" + SchoolCode + "'");
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
        /// <param name="temperature">温度</param>        
        /// /// <returns></returns>
        private double GetActualStudentCount(StudentStasticSearchViewModel searchModel, string SchoolCode, string grade, string IsComeSchool, string temperature)
        {
            StringBuilder sbSelHealth = new StringBuilder();
            sbSelHealth.Append("select * from Health_Info where 1=1");
            if (IsComeSchool != null && IsComeSchool != "")
                sbSelHealth.Append("  and IsComeSchool='" + IsComeSchool + "'");
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
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSelHealth.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSelHealth.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }
            if (temperature != "")
                sbSelHealth.Append(" and CAST( Temperature as float)>37.2");
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
        /// <param name="IsComeSchool">是否到校  是、否  </param>
        /// <param name="Temperature">体温  </param>
        /// <returns></returns>
        private double GetActualFacultystaffCount(StudentStasticSearchViewModel searchModel, string SchoolCode, string CheckType, string IsComeSchool, string Temperature)
        {
            StringBuilder sbSelHealth = new StringBuilder();
            sbSelHealth.Append("select * from Health_Info where 1=1");
            if (IsComeSchool != null && IsComeSchool != "")
                sbSelHealth.Append(" and IsComeSchool='" + IsComeSchool + "'");
            if (CheckType != null && CheckType != "")
                sbSelHealth.Append(" and CheckType='" + CheckType + "' ");
            if (SchoolCode != null && SchoolCode != "")
                sbSelHealth.Append("and facultystaff_InfoId in (select id from facultystaff_Info where SchoolCode='" + SchoolCode + "')");
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    sbSelHealth.Append(" and  CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    sbSelHealth.Append(" and  CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    sbSelHealth.Append(" and  CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSelHealth.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSelHealth.Append(" and  CONVERT(varchar(100), CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }
            if (Temperature != "")
            {
                sbSelHealth.Append(" and CAST( Temperature as float)>37.2");
            }
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
            result.StudentActualCount = Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "", "是", ""));
            result.FacultystaffCount = Convert.ToInt32(GetFacultystaffCount(searchModel.SchoolCode));
            result.FacultystaffActualCount = Convert.ToInt32(GetActualFacultystaffCount(searchModel, searchModel.SchoolCode, searchModel.Type, "", ""));

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
            double StudentHealthCount = GetActualStudentCount(searchModel, searchModel.SchoolCode, "", "", "");
            double FacultystaffHealthCount = GetActualFacultystaffCount(searchModel, searchModel.SchoolCode, searchModel.Type, "", "");
            HealthStatisticsMiddleModel result = new HealthStatisticsMiddleModel();
            result.StudentHealthCount = Convert.ToInt32(StudentHealthCount);
            result.FacultystaffHealthCount = Convert.ToInt32(FacultystaffHealthCount);
            result.PrimaryCount = Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "'1','2','3','3','4','5','6'", "", ""));
            result.JuniorCount = Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "'7','8','9'", "", ""));
            result.HighCount = Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "'10','11','12'", "", ""));

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


        public List<HealthEverySearchMiddleModel> GetHealthEverySearchMiddleModels(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature)
        {
            List<HealthEverySearchMiddleModel> result = new List<HealthEverySearchMiddleModel>();
            if (type == "学生")
            {
                StringBuilder sbSel = new StringBuilder();
                sbSel.Append("select h.*,s.IdNumber from Health_Info h left join Student_Info s on h.Student_InfoId=s.id where 1=1 and Student_InfoId is not null ");// and CheckType='到校前'
                if (IsComeSchool != "")
                {
                    sbSel.Append("  and (h.IsComeSchool = '" + IsComeSchool + "')");// AND (NotComeSchoolReason IS NOT NULL)
                }
                if (Temperature != "")
                {
                    sbSel.Append(" and CAST( h.Temperature as float)>37.2");
                }
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    //sbSel.Append("and Student_InfoId in (select id from Student_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                    sbSel.Append(" and s.SchoolCode='" + searchModel.SchoolCode + "'");
                }
                if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                }

                //if (searchModel.CheckType != null && searchModel.CheckType != "")
                //    sbSel.Append(" and CheckType='" + searchModel.CheckType + "'");
                sbSel.Append(" order by h.Createdate desc ");
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
                sbSel.Append("select  h.*,f.IdNumber from Health_Info h left join facultystaff_Info f on h.facultystaff_InfoId=f.id where 1=1 and facultystaff_InfoId is not null ");//  (IsComeSchool = '否') AND (NotComeSchoolReason IS NOT NULL)
                if (IsComeSchool != "")
                {
                    sbSel.Append("  and (h.IsComeSchool = '" + IsComeSchool + "')");// AND (NotComeSchoolReason IS NOT NULL)
                }
                if (Temperature != "")
                {
                    sbSel.Append(" and CAST( h.Temperature as float)>37.2");
                }
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    //sbSel.Append("and h.facultystaff_InfoId in (select id from facultystaff_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                    sbSel.Append(" and f.SchoolCode='" + searchModel.SchoolCode + "'");
                }
                //else
                //{
                //    sbSel.Append(" and facultystaff_InfoId is not null");
                //}
                if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

                }

                //if (grade != "")
                //    strSql.Append(" and GradeName in(" + grade + ")");
                if (searchModel.CheckType != null && searchModel.CheckType != "")
                    sbSel.Append(" and h.CheckType='" + searchModel.CheckType + "'");
                sbSel.Append(" order by h.Createdate desc ");
                sbSel.Append(" offset((" + (searchModel.page.CurrentPageNum + 1) + " - 1) * " + searchModel.page.PageSize + ") rows fetch next " +
                    searchModel.page.PageSize + " rows only ");

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                    connection.Close();
                }
            }
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    item.Telephone = GetTelephone(item.IdNumber);
                    item.IdNumber = Dtol.Helper.MD5.Decrypt(item.IdNumber);
                }
            }

            return result;
        }

        public int GetHealthEverySearchMiddleModelsTotal(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature)
        {
            List<HealthEverySearchMiddleModel> result = new List<HealthEverySearchMiddleModel>();
            if (type == "学生")
            {
                StringBuilder sbSel = new StringBuilder();
                sbSel.Append("select h.*,s.IdNumber,s.SchoolName from Health_Info h left join Student_Info s on h.Student_InfoId=s.id where 1=1 and Student_InfoId is not null ");// and CheckType='到校前'
                if (IsComeSchool != "")
                {
                    sbSel.Append("  and (h.IsComeSchool = '" + IsComeSchool + "')");// AND (NotComeSchoolReason IS NOT NULL)
                }
                if (Temperature != "")
                {
                    sbSel.Append(" and CAST( h.Temperature as float)>37.2");
                }
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    //sbSel.Append("and Student_InfoId in (select id from Student_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                    sbSel.Append(" and s.SchoolCode='" + searchModel.SchoolCode + "'");
                }
                if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                }
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
                sbSel.Append("select  h.*,f.IdNumber,f.SchoolName from Health_Info h left join facultystaff_Info f on h.facultystaff_InfoId=f.id where 1=1 and facultystaff_InfoId is not null ");//  (IsComeSchool = '否') AND (NotComeSchoolReason IS NOT NULL)
                if (IsComeSchool != "")
                {
                    sbSel.Append("  and (h.IsComeSchool = '" + IsComeSchool + "')");// AND (NotComeSchoolReason IS NOT NULL)
                }
                if (Temperature != "")
                {
                    sbSel.Append(" and CAST( h.Temperature as float)>37.2");
                }
                if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
                {
                    //sbSel.Append("and h.facultystaff_InfoId in (select id from facultystaff_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
                    sbSel.Append(" and f.SchoolCode='" + searchModel.SchoolCode + "'");
                }
                //else
                //{
                //    sbSel.Append(" and facultystaff_InfoId is not null");
                //}
                if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

                }

                //if (grade != "")
                //    strSql.Append(" and GradeName in(" + grade + ")");
                if (searchModel.CheckType != null && searchModel.CheckType != "")
                    sbSel.Append(" and h.CheckType='" + searchModel.CheckType + "'");

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                    connection.Close();
                }

            }
            return result.Count;
        }
        private string GetTelephone(string idNum)
        {
            string Telephone = string.Empty;

            string sqlSel = "select top 1 Telephone from StudentRegisterHeath_Info where Idnumber = '" + idNum + "'";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<dynamic>(sqlSel).ToList();
                if (list.Count > 0)
                    Telephone = list[0].Telephone;
                connection.Close();
            }
            return Telephone;
        }
        public List<HealthInfoStatasticMiddleModel> GetHealthInfoStatasticMiddles(StudentStasticSearchViewModel searchModel)
        {
            List<HealthInfoStatasticMiddleModel> result = new List<HealthInfoStatasticMiddleModel>();
            StringBuilder sbSel = new StringBuilder();
            sbSel.Append("select info.* from (");
            sbSel.Append("select count(*) CountReason,NotComeSchoolReason as Reason,sc.SchoolName,sc.SchoolCode");
            sbSel.Append(" from Health_Info h  left join Student_Info s on h.Student_InfoId = s.id left join School_Info sc on s.SchoolCode = sc.SchoolCode");
            sbSel.Append(" WHERE(IsComeSchool = '否') AND(NotComeSchoolReason IS NOT NULL) and h.Student_InfoId is not null");
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    sbSel.Append(" and  h.CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    sbSel.Append(" and  h.CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    sbSel.Append(" and  h.CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }

            if (searchModel.Type != null && searchModel.Type != "")
                sbSel.Append(" and h.CheckType='" + searchModel.Type + "'");
            sbSel.Append(" group by h.NotComeSchoolReason, sc.SchoolName, sc.SchoolCode");
            sbSel.Append(" union ");
            sbSel.Append("select count(*) CountReason,'到校后发热学' as Reason,sc.SchoolName,sc.SchoolCode");
            sbSel.Append(" from Health_Info h  left join Student_Info s on h.Student_InfoId = s.id left join School_Info sc on s.SchoolCode = sc.SchoolCode");
            sbSel.Append(" WHERE(IsComeSchool = '是') and h.Student_InfoId is not null and cast(Temperature as float) > 37.2");
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    sbSel.Append(" and  h.CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    sbSel.Append(" and  h.CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    sbSel.Append(" and  h.CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }

            if (searchModel.Type != null && searchModel.Type != "")
                sbSel.Append(" and h.CheckType='" + searchModel.Type + "'");
            sbSel.Append(" group by sc.SchoolName, sc.SchoolCode");
            sbSel.Append(" union ");
            sbSel.Append(" select count(*) CountReason,'发热未到校' Reason,sc.SchoolName,sc.SchoolCode");
            sbSel.Append(" from Health_Info h left join Student_Info s on h.Student_InfoId = s.id left join School_Info sc on s.SchoolCode = sc.SchoolCode ");
            sbSel.Append(" WHERE(IsComeSchool = '否') AND(NotComeSchoolReason IS NULL) and h.Student_InfoId is not null and cast(Temperature as float) > 37.2");
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //    sbSel.Append(" and  h.CreateDate between '" + searchModel.StartDate + "' and '" + searchModel.EndDate + "'");
            //else if (searchModel.StartDate != null && searchModel.EndDate == null)
            //    sbSel.Append(" and  h.CreateDate>'" + searchModel.StartDate + "'");
            //else if (searchModel.StartDate == null && searchModel.EndDate != null)
            //    sbSel.Append(" and  h.CreateDate<'" + searchModel.EndDate + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }

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


        public HealthInfoFollowStatasticMiddleModel GetHealthInfoFollowStatastic(StudentStasticSearchViewModel searchModel)
        {
            HealthInfoFollowStatasticMiddleModel result = new HealthInfoFollowStatasticMiddleModel();
            int studentNoComSchoolFever = Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "", "否", "37.2"));
            int studentNoComSchool = Convert.ToInt32(GetActualStudentCount(searchModel, searchModel.SchoolCode, "", "否", ""));
            int studentComSchoolFever = Convert.ToInt32(GetStudentComSchool(searchModel, "37.2"));
            int teachComSchoolFever = Convert.ToInt32(GetActualFacultystaffCount(searchModel, searchModel.SchoolCode, searchModel.Type, "是", "37.2"));
            int teachNoComSchoolFever = Convert.ToInt32(GetActualFacultystaffCount(searchModel, searchModel.SchoolCode, searchModel.Type, "否", "37.2"));
            int teachNoComSchool = Convert.ToInt32(GetActualFacultystaffCount(searchModel, searchModel.SchoolCode, searchModel.Type, "否", ""));

            result.FollowPerson = studentNoComSchoolFever + studentComSchoolFever + teachNoComSchoolFever + teachComSchoolFever;
            result.IsComSchoolPerson = studentComSchoolFever + teachComSchoolFever;
            result.NoCoSchoolPerson = studentNoComSchool + teachNoComSchool;

            return result;
        }

        private double GetStudentComSchool(StudentStasticSearchViewModel searchModel, string Temperature)
        {
            double result = 0;
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from [dbo].[Student_DayandNight_Info] where 1=1");
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
            {
                sbSql.Append(" and SchoolName in (select SchoolName from School_Info where SchoolCode='" + searchModel.SchoolCode + "')");
            }
            if (searchModel.Type != null && searchModel.Type != "")
                sbSql.Append(" and AddTimeInterval='" + searchModel.Type + "'");
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSql.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSql.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            }
            if (Temperature != "")
            {
                sbSql.Append(" and  CAST( Temperature as float)>37.2");
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var list = connection.Query<dynamic>(sbSql.ToString()).ToList();
                if (list.Count > 0)
                    result = list.Count;
                connection.Close();
            }
            return result;
        }

        public List<HealthEverySearchMiddleModel> GetStudentComeSchoolHealthInfo(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature)
        {
            List<HealthEverySearchMiddleModel> result = new List<HealthEverySearchMiddleModel>();
            StringBuilder sbSel = new StringBuilder();
            sbSel.Append("select id,name,IdNumber,Temperature,IsComeSchool,NotComeJinReason NotComeSchoolReason,AddTimeInterval CheckType,AddCreateDate Createdate from [dbo].[Student_DayandNight_Info] where 1=1");
            if (IsComeSchool != "")
            {
                sbSel.Append("  and (IsComeSchool = '" + IsComeSchool + "')");// AND (NotComeSchoolReason IS NOT NULL)
            }
            if (Temperature != "")
            {
                sbSel.Append(" and CAST( Temperature as float)>37.2");
            }
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
            {
                sbSel.Append("and SchoolName in (select SchoolName from School_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
            }
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSel.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSel.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            }

            if (searchModel.CheckType != null && searchModel.CheckType != "")
                sbSel.Append(" and AddTimeInterval='" + searchModel.CheckType + "'");
            sbSel.Append(" order by AddCreateDate desc ");
            sbSel.Append(" offset((" + (searchModel.page.CurrentPageNum + 1) + " - 1) * " + searchModel.page.PageSize + ") rows fetch next " +
                searchModel.page.PageSize + " rows only ");
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                connection.Close();
            }
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    item.Telephone = GetTelephone(item.IdNumber);
                    item.IdNumber = Dtol.Helper.MD5.Decrypt(item.IdNumber);
                }
            }

            return result;
        }

        public int GetStudentComeSchoolHealthInfoTotal(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature)
        {
            List<HealthEverySearchMiddleModel> result = new List<HealthEverySearchMiddleModel>();
            StringBuilder sbSel = new StringBuilder();
            sbSel.Append("select id,name,IdNumber,Temperature,IsComeSchool,NotComeJinReason NotComeSchoolReason,AddTimeInterval CheckType,AddCreateDate Createdate from [dbo].[Student_DayandNight_Info] where 1=1");
            if (IsComeSchool != "")
            {
                sbSel.Append("  and (IsComeSchool = '" + IsComeSchool + "')");// AND (NotComeSchoolReason IS NOT NULL)
            }
            if (Temperature != "")
            {
                sbSel.Append(" and CAST( Temperature as float)>37.2");
            }
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
            {
                sbSel.Append("and SchoolName in (select SchoolName from School_Info where 1=1  and SchoolCode ='" + searchModel.SchoolCode + "')");
            }
            if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
            {
                sbSel.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sbSel.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            }

            if (searchModel.CheckType != null && searchModel.CheckType != "")
                sbSel.Append(" and AddTimeInterval='" + searchModel.CheckType + "'");
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList();
                connection.Close();
            }

            return result.Count;
        }

        public List<SchoolSituationStatisticsMiddle> GetSchoolSituationStatistics(StudentStasticSearchViewModel searchModel, string type)
        {
            List<SchoolSituationStatisticsMiddle> result = new List<SchoolSituationStatisticsMiddle>();
            string sqlSel = "select * from School_Info where 1=1 and SchoolCode is not null";
            if (searchModel.SchoolCode != null && searchModel.SchoolCode != "")
            {
                sqlSel += " and SchoolCode='" + searchModel.SchoolCode + "'";
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<SchoolSituationStatisticsMiddle>(sqlSel).ToList();
                connection.Close();
            }
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    item.HealthType1 = GetHealthType(searchModel, type, "流感", item.SchoolCode);
                    item.HealthType2 = GetHealthType(searchModel, type, "麻疹", item.SchoolCode);
                    item.HealthType3 = GetHealthType(searchModel, type, "水痘", item.SchoolCode);
                    item.HealthType4 = GetHealthType(searchModel, type, "猩红热", item.SchoolCode);
                    item.HealthType5 = GetHealthType(searchModel, type, "诺如", item.SchoolCode);
                    item.HealthType6 = GetHealthType(searchModel, type, "其他", item.SchoolCode);

                }
            }
            return result;
        }

        private int GetHealthType(StudentStasticSearchViewModel searchModel,string type, string healthType,string SchoolCode)
        {
            int result = 0;
            if (type == "学生")
            {

                if (searchModel.Type != null && searchModel.Type != "")
                {
                    if(searchModel.Type == "到校前")
                    {
                        StringBuilder sbSel = new StringBuilder();
                        sbSel.Append("select h.*,s.IdNumber from Health_Info h left join Student_Info s on h.Student_InfoId=s.id where 1=1 and Student_InfoId is not null ");// and CheckType='到校前'
                        sbSel.Append("  and (h.IsComeSchool = '否')");// AND (NotComeSchoolReason IS NOT NULL)
                        if (SchoolCode != null && SchoolCode != "")
                        {
                            sbSel.Append(" and s.SchoolCode='" + SchoolCode + "'");
                        }
                        if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                        {
                            sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                        }
                        else
                        {
                            sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                        }

                        if (healthType != "")
                        {
                            sbSel.Append(" and NotComeSchoolReason='" + healthType + "'");
                        }

                        using (var connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList().Count;
                            connection.Close();
                        }
                    }
                    else
                    {
                        StringBuilder sbSel = new StringBuilder();
                        sbSel.Append("select id,name,IdNumber,Temperature,IsComeSchool,NotComeJinReason NotComeSchoolReason,AddTimeInterval CheckType,AddCreateDate Createdate from [dbo].[Student_DayandNight_Info] where 1=1");
                        sbSel.Append("  and (IsComeSchool = '否')");// AND (NotComeSchoolReason IS NOT NULL)
                        if (SchoolCode != null && SchoolCode != "")
                        {
                            sbSel.Append("and SchoolName in (select SchoolName from School_Info where 1=1  and SchoolCode ='" + SchoolCode + "')");
                        }
                        if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                        {
                            sbSel.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                        }
                        else
                        {
                            sbSel.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                        }
                        if (healthType != "")
                        {
                            sbSel.Append(" and NotComeJinReason='" + healthType + "'");
                        }

                        if (searchModel.Type != null && searchModel.Type != "")
                            sbSel.Append(" and AddTimeInterval='" + searchModel.Type + "'");
                        using (var connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList().Count;
                            connection.Close();
                        }

                    }
                }
                else
                {
                    #region 到校前数据
                    int before = 0;
                    StringBuilder sbSel = new StringBuilder();
                    sbSel.Append("select h.*,s.IdNumber from Health_Info h left join Student_Info s on h.Student_InfoId=s.id where 1=1 and Student_InfoId is not null ");// and CheckType='到校前'
                    sbSel.Append("  and (h.IsComeSchool = '否')");// AND (NotComeSchoolReason IS NOT NULL)
                    if (SchoolCode != null && SchoolCode != "")
                    {
                        sbSel.Append(" and s.SchoolCode='" + SchoolCode + "'");
                    }
                    if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                    {
                        sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                    }
                    else
                    {
                        sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                    }

                    if (healthType != "")
                    {
                        sbSel.Append(" and NotComeSchoolReason='" + healthType + "'");
                    }

                    using (var connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        before = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList().Count;
                        connection.Close();
                    }
                    #endregion

                    #region 到校后
                    int after = 0;
                    StringBuilder sbSelAfter = new StringBuilder();
                    sbSelAfter.Append("select id,name,IdNumber,Temperature,IsComeSchool,NotComeJinReason NotComeSchoolReason,AddTimeInterval CheckType,AddCreateDate Createdate from [dbo].[Student_DayandNight_Info] where 1=1");
                    sbSelAfter.Append("  and (IsComeSchool = '否')");// AND (NotComeSchoolReason IS NOT NULL)
                    if (SchoolCode != null && SchoolCode != "")
                    {
                        sbSelAfter.Append("and SchoolName in (select SchoolName from School_Info where 1=1  and SchoolCode ='" + SchoolCode + "')");
                    }
                    if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                    {
                        sbSelAfter.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                    }
                    else
                    {
                        sbSelAfter.Append(" and  CONVERT(varchar(100), AddCreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                    }
                    if (searchModel.Type != null && searchModel.Type != "")
                        sbSelAfter.Append(" and AddTimeInterval='" + searchModel.Type + "'");
                    if (healthType != "")
                    {
                        sbSel.Append(" and NotComeJinReason='" + healthType + "'");
                    }


                    using (var connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        after = connection.Query<HealthEverySearchMiddleModel>(sbSelAfter.ToString()).ToList().Count;
                        connection.Close();
                    }
                    #endregion
                    result = before + after;
                }
            }
            else
            {
                StringBuilder sbSel = new StringBuilder();
                sbSel.Append("select  h.*,f.IdNumber from Health_Info h left join facultystaff_Info f on h.facultystaff_InfoId=f.id where 1=1 and facultystaff_InfoId is not null ");//  (IsComeSchool = '否') AND (NotComeSchoolReason IS NOT NULL)

                sbSel.Append("  and (h.IsComeSchool = '否')");// AND (NotComeSchoolReason IS NOT NULL)
                if (SchoolCode != null && SchoolCode != "")
                {
                    sbSel.Append(" and f.SchoolCode='" + SchoolCode + "'");
                }
                if (searchModel.StartDate != null && searchModel.StartDate.ToString() != "")
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Parse(searchModel.StartDate.ToString()).ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    sbSel.Append(" and  CONVERT(varchar(100), h.CreateDate, 23) ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

                }

                if (searchModel.Type != null && searchModel.Type != "")
                    sbSel.Append(" and h.CheckType='" + searchModel.Type + "'");
                if(healthType!="")
                {
                    sbSel.Append(" and NotComeSchoolReason='" + healthType + "'");
                }
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<HealthEverySearchMiddleModel>(sbSel.ToString()).ToList().Count;
                    connection.Close();
                }
            }

            return result;
        }

        private int GetStudentHealthType(StudentStasticSearchViewModel searchModel, string type)
        {
            int result = 0;

            return result;
        }
    }
}
