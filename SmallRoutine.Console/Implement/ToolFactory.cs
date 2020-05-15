using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SmallRoutineTiming.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmallRoutineTiming.Implement
{
    /// <summary>
    /// 创建不同数据库的dbcontext工厂
    /// </summary>
    public  class ToolFactory :IToolFactory
    {
        public DtolContext getDbContext() {

            var optionsBuilder = new DbContextOptionsBuilder<DtolContext>();
          
           var   configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));


            return new DtolContext(optionsBuilder.Options);
        }

        //public MysqlContext getMysqlDbContext()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<MysqlContext>();

        //    var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        //    optionsBuilder.UseMySQL(configuration.GetConnectionString("MysqlConnection"));


        //    return new MysqlContext(optionsBuilder.Options);
        //}
    }
}
