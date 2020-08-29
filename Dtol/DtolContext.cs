using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dtol.dtol;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Dtol
{
    public class DtolContext : DbContext
    {
        [Obsolete]
        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider((_, __) => true) });

        public DtolContext()
        {
        }
        public DbSet<UserFiles_Info> UserFiles_Info { get; set; }
        public DbSet<Except_Info_Employ> Except_Info_Employ { get; set; }
        public DbSet<Except_Info_Student> Except_Info_Student { get; set; }
        public DbSet<Class_Info> Class_Info { get; set; }
        public DbSet<facultystaff_Info> facultystaff_Info { get; set; }
        public DbSet<Grade_Info> Grade_Info { get; set; }
        public DbSet<Health_Info> Health_Info { get; set; }
        public DbSet<School_Info> School_Info { get; set; }
        public DbSet<Station_Info> Station_Info { get; set; }
        public DbSet<Student_Info> Student_Info { get; set; }
        public DbSet<UploadFile> UploadFile { get; set; }
        public DbSet<Depart_Info> Depart_Info { get; set; }
        public DbSet<User_Info> User_Info { get; set; }
        public DbSet<ClassManager_Relate> ClassManager_Relate { get; set; }
        public DbSet<StaffStation_Relate> StaffStation_Relate { get; set; }

        public DbSet<ReadLog> ReadLog { get; set; }

        public DbSet<Student_DayandNight_Info> Student_DayandNight_Info { get; set; }

        public DbSet<User_System> User_System { get; set; }
        public DbSet<User_Rights> User_Rights { get; set; }
        public DbSet<Template_Employment> Template_Employment { get; set; }
        public DbSet<Template_Student> Template_Student { get; set; }
        public DbSet<User_Group> User_Group { get; set; }

        //删除的学生基本信息 备份保存表
        public DbSet<Student_Info_Delete> Student_Info_Delete { get; set; }
        


        public DtolContext(DbContextOptions<DtolContext> options)
       : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var loggerFactory = new LoggerFactory();
            //loggerFactory.AddProvider(new EFLoggerProvider());
            //optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    } 
}

