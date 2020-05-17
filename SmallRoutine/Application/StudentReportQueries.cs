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
    public class StudentReportQueries: IStudentReportQueries
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

            if(searchModel.GradeName==null|| searchModel.GradeName =="")
            {
                var gz = GetStudentListBySearchModel(searchModel, "'10','11','12'","高中");
                result.AddRange(gz);
                var cz = GetStudentListBySearchModel(searchModel, "'7','8','9'", "初中");
                result.AddRange(cz);
                var xx = GetStudentListBySearchModel(searchModel, "'1','2','3','3','4','5','6'", "小学");
                result.AddRange(xx);
            }

            return result;
        }/// <summary>
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
            if(searchModel.Type != null && searchModel.Type != "")
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

        private List<StudentReportMiddle> GetStudentListBySearchModel(StudentStasticSearchViewModel searchModel, string grade,string gradeName)
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

    }
}
