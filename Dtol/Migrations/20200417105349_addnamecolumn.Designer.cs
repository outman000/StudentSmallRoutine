﻿// <auto-generated />
using System;
using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dtol.Migrations
{
    [DbContext(typeof(DtolContext))]
    [Migration("20200417105349_addnamecolumn")]
    partial class addnamecolumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dtol.dtol.ClassManager_Relate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Class_InfoId");

                    b.Property<int?>("facultystaff_InfoId");

                    b.HasKey("id");

                    b.HasIndex("Class_InfoId");

                    b.HasIndex("facultystaff_InfoId");

                    b.ToTable("ClassManager_Relate");
                });

            modelBuilder.Entity("Dtol.dtol.Class_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassCode");

                    b.Property<string>("ClassName");

                    b.Property<int?>("Grade_InfoId");

                    b.HasKey("id");

                    b.HasIndex("Grade_InfoId");

                    b.ToTable("Class_Info");
                });

            modelBuilder.Entity("Dtol.dtol.Depart_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartCode");

                    b.Property<string>("DepartName");

                    b.Property<int?>("Student_InfoId");

                    b.HasKey("id");

                    b.HasIndex("Student_InfoId");

                    b.ToTable("Depart_Info");
                });

            modelBuilder.Entity("Dtol.dtol.Grade_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeCode");

                    b.Property<string>("GradeName");

                    b.HasKey("id");

                    b.ToTable("Grade_Info");
                });

            modelBuilder.Entity("Dtol.dtol.Health_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Createdate");

                    b.Property<string>("IdNumber");

                    b.Property<string>("IsComeSchool");

                    b.Property<string>("IsFamilyHot");

                    b.Property<string>("IsFamilyThroat");

                    b.Property<string>("IsFamilyWeakt");

                    b.Property<string>("IsHot");

                    b.Property<string>("IsThroat");

                    b.Property<string>("IsTouch");

                    b.Property<string>("IsWeak");

                    b.Property<string>("Name");

                    b.Property<int?>("Student_InfoId");

                    b.Property<string>("Temperature");

                    b.Property<int?>("facultystaff_InfoId");

                    b.HasKey("id");

                    b.HasIndex("Student_InfoId");

                    b.HasIndex("facultystaff_InfoId");

                    b.ToTable("Health_Info");
                });

            modelBuilder.Entity("Dtol.dtol.School_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SchoolCode");

                    b.Property<string>("SchoolName");

                    b.HasKey("id");

                    b.ToTable("School_Info");
                });

            modelBuilder.Entity("Dtol.dtol.StaffStation_Relate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Station_InfoId");

                    b.Property<int?>("facultystaff_InfoId");

                    b.HasKey("id");

                    b.HasIndex("Station_InfoId");

                    b.HasIndex("facultystaff_InfoId");

                    b.ToTable("StaffStation_Relate");
                });

            modelBuilder.Entity("Dtol.dtol.Station_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Depart_InfoId");

                    b.Property<int?>("School_Infoid");

                    b.Property<string>("StaffCode");

                    b.Property<string>("StaffName");

                    b.HasKey("id");

                    b.HasIndex("Depart_InfoId");

                    b.HasIndex("School_Infoid");

                    b.ToTable("Station_Info");
                });

            modelBuilder.Entity("Dtol.dtol.StudentRegisterHeath_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BackJinDate");

                    b.Property<string>("BeforeTianjin");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Destination");

                    b.Property<string>("ForteenDaysExcepting");

                    b.Property<string>("Guardian");

                    b.Property<string>("Idnumber");

                    b.Property<string>("IsPassHubei");

                    b.Property<string>("IsleaveJin");

                    b.Property<string>("PassHubeiDetail");

                    b.Property<string>("Peers");

                    b.Property<string>("PeersTelephone");

                    b.Property<string>("Residencetemporary");

                    b.Property<string>("Telephone");

                    b.Property<string>("Temperature");

                    b.Property<string>("Traffic");

                    b.HasKey("id");

                    b.ToTable("StudentRegisterHeath_Info");
                });

            modelBuilder.Entity("Dtol.dtol.Student_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("ClassCode");

                    b.Property<string>("ClassName");

                    b.Property<string>("Country");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("GradeCode");

                    b.Property<string>("GradeName");

                    b.Property<string>("IdNumber");

                    b.Property<string>("Name");

                    b.Property<string>("PermanentAddress");

                    b.Property<string>("SchoolCode");

                    b.Property<string>("SchoolName");

                    b.Property<string>("Sex");

                    b.Property<int?>("StudentRegisterHeath_InfoId");

                    b.Property<int?>("class_InfoId");

                    b.Property<string>("tag");

                    b.HasKey("id");

                    b.HasIndex("StudentRegisterHeath_InfoId");

                    b.HasIndex("class_InfoId");

                    b.ToTable("Student_Info");
                });

            modelBuilder.Entity("Dtol.dtol.UploadFile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Catalog");

                    b.Property<string>("FileName");

                    b.Property<int>("ImgIndex");

                    b.Property<string>("InternalName");

                    b.Property<string>("Length");

                    b.Property<string>("Path");

                    b.Property<string>("PhysisticName");

                    b.Property<string>("Url");

                    b.Property<string>("pathMobile");

                    b.Property<string>("path_server");

                    b.Property<string>("upload_percent");

                    b.HasKey("id");

                    b.ToTable("UploadFile");
                });

            modelBuilder.Entity("Dtol.dtol.User_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Idnumber");

                    b.Property<string>("password");

                    b.HasKey("id");

                    b.ToTable("User_Info");
                });

            modelBuilder.Entity("Dtol.dtol.facultystaff_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Country");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DepartCode");

                    b.Property<string>("DepartName");

                    b.Property<string>("IdNumber");

                    b.Property<string>("Name");

                    b.Property<string>("PermanentAddress");

                    b.Property<string>("SchoolCode");

                    b.Property<string>("SchoolName");

                    b.Property<string>("Sex");

                    b.Property<string>("StaffCode");

                    b.Property<string>("StaffName");

                    b.Property<int?>("StudentRegisterHeath_InfoId");

                    b.Property<int?>("station_InfoId");

                    b.HasKey("id");

                    b.HasIndex("StudentRegisterHeath_InfoId");

                    b.HasIndex("station_InfoId");

                    b.ToTable("facultystaff_Info");
                });

            modelBuilder.Entity("Dtol.dtol.ClassManager_Relate", b =>
                {
                    b.HasOne("Dtol.dtol.Class_Info", "Class_Info")
                        .WithMany()
                        .HasForeignKey("Class_InfoId");

                    b.HasOne("Dtol.dtol.facultystaff_Info", "facultystaff_Info")
                        .WithMany()
                        .HasForeignKey("facultystaff_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Class_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Grade_Info", "Grade_Info")
                        .WithMany("class_Infos")
                        .HasForeignKey("Grade_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Depart_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Student_Info", "Student_Info")
                        .WithMany()
                        .HasForeignKey("Student_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Health_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Student_Info", "Student_Info")
                        .WithMany("Health_Info")
                        .HasForeignKey("Student_InfoId");

                    b.HasOne("Dtol.dtol.facultystaff_Info", "facultystaff_Info")
                        .WithMany("Health_Info")
                        .HasForeignKey("facultystaff_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.StaffStation_Relate", b =>
                {
                    b.HasOne("Dtol.dtol.Station_Info", "Station_Info")
                        .WithMany()
                        .HasForeignKey("Station_InfoId");

                    b.HasOne("Dtol.dtol.facultystaff_Info", "facultystaff_Info")
                        .WithMany()
                        .HasForeignKey("facultystaff_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Station_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Depart_Info", "Depart_Info")
                        .WithMany("class_Infos")
                        .HasForeignKey("Depart_InfoId");

                    b.HasOne("Dtol.dtol.School_Info")
                        .WithMany("Station_Info")
                        .HasForeignKey("School_Infoid");
                });

            modelBuilder.Entity("Dtol.dtol.Student_Info", b =>
                {
                    b.HasOne("Dtol.dtol.StudentRegisterHeath_Info", "StudentRegisterHeath_Info")
                        .WithMany()
                        .HasForeignKey("StudentRegisterHeath_InfoId");

                    b.HasOne("Dtol.dtol.Class_Info", "class_Info")
                        .WithMany("Student_Info")
                        .HasForeignKey("class_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.facultystaff_Info", b =>
                {
                    b.HasOne("Dtol.dtol.StudentRegisterHeath_Info", "StudentRegisterHeath_Info")
                        .WithMany()
                        .HasForeignKey("StudentRegisterHeath_InfoId");

                    b.HasOne("Dtol.dtol.Station_Info", "station_Info")
                        .WithMany()
                        .HasForeignKey("station_InfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
