using Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using SmallRoutine.ConsoleSendMsg.IStudentMessageQueries;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace SmallRoutine.ConsoleSendMsg.StudentMessageQueries
{
    public class MessageQueries: IMessageQueries
    {
        private string _connectionString = string.Empty;

        public MessageQueries()
        {
            _connectionString = "Server=D41ICKRFDL1HRNM;Database=StudentSmallRoutine;Trusted_Connection=True;";
            //var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //_connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        //7:30 提醒未进行健康信息情况填报的教职员工和学生家长 填写体温等健康信息
        public List<string> GetListsBeforeToSchool()
        {
 
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select a.IdNumber from User_Info a where IdNumber not in ( select  b.IdNumber from  Health_Info b  where CONVERT(VARCHAR(50),b.Createdate,23)='" + DateTime.Now + "' and  checktype='到校前' ) ";
                var result = connection.Query<string>(sql).AsList();
                connection.Close();
                return result;
            }

        }
    }
}
