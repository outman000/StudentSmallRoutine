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

        public DbSet<Class_Info> Class_Info { get; set; }
        public DbSet<facultystaff_Info> facultystaff_Info { get; set; }
        public DbSet<Grade_Info> Grade_Info { get; set; }
        public DbSet<Health_Info> Health_Info { get; set; }
        public DbSet<School_Info> School_Info { get; set; }
        public DbSet<Station_Info> Station_Info { get; set; }
        public DbSet<Student_Info> Student_Info { get; set; }
        public DbSet<UploadFile> UploadFile { get; set; }
        public DbSet<Depart_Info> Depart_Info { get; set; }
        
        public DtolContext(DbContextOptions<DtolContext> options)
       : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    } 
}

