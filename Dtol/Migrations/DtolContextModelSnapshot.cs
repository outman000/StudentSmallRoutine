﻿// <auto-generated />
using System;
using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dtol.Migrations
{
    [DbContext(typeof(DtolContext))]
    partial class DtolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ClassCode");

                    b.Property<int?>("Class_InfoId");

                    b.Property<string>("IdNumber");

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

            modelBuilder.Entity("Dtol.dtol.Except_Info_Employ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Idnumber");

                    b.Property<string>("Name");

                    b.Property<string>("Temperature");

                    b.Property<int?>("UserFiles_InfoId");

                    b.Property<int?>("facultystaff_InfoId");

                    b.HasKey("Id");

                    b.HasIndex("UserFiles_InfoId");

                    b.HasIndex("facultystaff_InfoId");

                    b.ToTable("Except_Info_Employ");
                });

            modelBuilder.Entity("Dtol.dtol.Except_Info_Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Idnumber");

                    b.Property<string>("Name");

                    b.Property<string>("Temperature");

                    b.Property<int?>("UserFiles_InfoId");

                    b.Property<int?>("student_InfoId");

                    b.HasKey("Id");

                    b.HasIndex("UserFiles_InfoId");

                    b.HasIndex("student_InfoId");

                    b.ToTable("Except_Info_Student");
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

                    b.Property<string>("CheckType");

                    b.Property<DateTime?>("Createdate");

                    b.Property<string>("IdNumber");

                    b.Property<string>("IsAggregate");

                    b.Property<string>("IsAggregateContain");

                    b.Property<string>("IsBulu");

                    b.Property<string>("IsComeSchool");

                    b.Property<string>("IsFamilyHot");

                    b.Property<string>("IsFamilyThroat");

                    b.Property<string>("IsFamilyWeakt");

                    b.Property<string>("IsHot");

                    b.Property<string>("IsThroat");

                    b.Property<string>("IsTianJin");

                    b.Property<string>("IsTouch");

                    b.Property<string>("IsWeak");

                    b.Property<string>("Name");

                    b.Property<string>("NotComeSchoolReason")
                        .HasMaxLength(100);

                    b.Property<string>("PermanentAddress");

                    b.Property<int?>("Student_InfoId");

                    b.Property<string>("Student_Info_Deleteid");

                    b.Property<string>("Temperature");

                    b.Property<int?>("facultystaff_InfoId");

                    b.HasKey("id");

                    b.HasIndex("Student_InfoId");

                    b.HasIndex("Student_Info_Deleteid");

                    b.HasIndex("facultystaff_InfoId");

                    b.ToTable("Health_Info");
                });

            modelBuilder.Entity("Dtol.dtol.ReadLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("openid");

                    b.HasKey("id");

                    b.ToTable("ReadLog");
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

                    b.Property<string>("IdNumber");

                    b.Property<string>("StaffCode");

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

                    b.Property<string>("Name");

                    b.Property<string>("PassHubeiDetail");

                    b.Property<string>("Peers");

                    b.Property<string>("PeersTelephone");

                    b.Property<string>("PermanentAddress");

                    b.Property<string>("Residencetemporary");

                    b.Property<string>("Telephone");

                    b.Property<string>("Temperature");

                    b.Property<string>("Traffic");

                    b.HasKey("id");

                    b.ToTable("StudentRegisterHeath_Info");
                });

            modelBuilder.Entity("Dtol.dtol.Student_DayandNight_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddCreateDate");

                    b.Property<string>("AddTimeInterval");

                    b.Property<string>("ClassName");

                    b.Property<string>("GradeName");

                    b.Property<string>("IdNumber");

                    b.Property<string>("IsComeSchool");

                    b.Property<string>("IsTianJin");

                    b.Property<string>("Name");

                    b.Property<string>("NotComeJinReason");

                    b.Property<string>("SchoolName");

                    b.Property<string>("Temperature");

                    b.Property<string>("tag");

                    b.HasKey("id");

                    b.ToTable("Student_DayandNight_Info");
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

            modelBuilder.Entity("Dtol.dtol.Student_Info_Delete", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("ClassCode");

                    b.Property<string>("ClassName");

                    b.Property<string>("Country");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("GradeCode");

                    b.Property<string>("GradeName");

                    b.Property<string>("IdNumber");

                    b.Property<string>("Memo");

                    b.Property<string>("Name");

                    b.Property<string>("PermanentAddress");

                    b.Property<string>("SchoolCode");

                    b.Property<string>("SchoolName");

                    b.Property<string>("Sex");

                    b.Property<int>("StudentRegisterHeath_InfoId");

                    b.Property<int>("Student_id");

                    b.Property<int>("class_InfoId");

                    b.Property<string>("tag");

                    b.HasKey("id");

                    b.ToTable("Student_Info_Delete");
                });

            modelBuilder.Entity("Dtol.dtol.Template_Employment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualComeSchoolCount");

                    b.Property<int?>("ComeSchoolHotCount");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("DepartCode");

                    b.Property<string>("DepartName");

                    b.Property<int?>("NotComeSchoolByHotCount");

                    b.Property<int?>("NotComeSchoolByOtherCount");

                    b.Property<int?>("NotComeSchoolByOutCount");

                    b.Property<int?>("NotComeSchoolCount");

                    b.Property<string>("SchoolCode");

                    b.Property<string>("SchoolName");

                    b.Property<int?>("ShouldComeSchoolCount");

                    b.Property<string>("StaffCode");

                    b.Property<string>("StaffName");

                    b.Property<string>("type");

                    b.HasKey("id");

                    b.ToTable("Template_Employment");
                });

            modelBuilder.Entity("Dtol.dtol.Template_Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualComeSchoolCount");

                    b.Property<string>("ClassCode");

                    b.Property<string>("ClassName");

                    b.Property<int?>("ComeSchoolHotCount");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("GradeCode");

                    b.Property<string>("GradeName");

                    b.Property<int?>("NotComeSchoolByHotCount");

                    b.Property<int?>("NotComeSchoolByOtherCount");

                    b.Property<int?>("NotComeSchoolByOutCount");

                    b.Property<int?>("NotComeSchoolCount");

                    b.Property<string>("SchoolCode");

                    b.Property<string>("SchoolName");

                    b.Property<int?>("ShouldComeSchoolCount");

                    b.Property<string>("type");

                    b.HasKey("id");

                    b.ToTable("Template_Student");
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

            modelBuilder.Entity("Dtol.dtol.UserFiles_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName");

                    b.Property<string>("Idnumber");

                    b.Property<int>("ImgIndex");

                    b.Property<string>("InternalName");

                    b.Property<string>("Length");

                    b.Property<string>("Path");

                    b.Property<string>("Url");

                    b.Property<string>("pathMobile");

                    b.Property<string>("path_server");

                    b.Property<string>("upload_percent");

                    b.HasKey("id");

                    b.ToTable("UserFiles_Info");
                });

            modelBuilder.Entity("Dtol.dtol.User_Group", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Code")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Creatdate");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("StationCodes");

                    b.Property<string>("StationNames")
                        .HasMaxLength(500);

                    b.Property<string>("Status");

                    b.Property<string>("UpdateUser");

                    b.Property<DateTime?>("Updatedate");

                    b.Property<string>("bak1")
                        .HasMaxLength(1000);

                    b.Property<string>("bak2")
                        .HasMaxLength(1000);

                    b.Property<string>("bak3")
                        .HasMaxLength(1000);

                    b.Property<string>("bak4")
                        .HasMaxLength(1000);

                    b.Property<string>("bak5")
                        .HasMaxLength(1000);

                    b.HasKey("ID");

                    b.ToTable("User_Group");
                });

            modelBuilder.Entity("Dtol.dtol.User_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Idnumber");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("openid");

                    b.Property<string>("password");

                    b.Property<string>("unionid");

                    b.HasKey("id");

                    b.ToTable("User_Info");
                });

            modelBuilder.Entity("Dtol.dtol.User_Relate_Info_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Station_InfoId");

                    b.Property<int>("User_InfoId");

                    b.HasKey("Id");

                    b.HasIndex("Station_InfoId");

                    b.HasIndex("User_InfoId");

                    b.ToTable("User_Relate_Info_Role");
                });

            modelBuilder.Entity("Dtol.dtol.User_Rights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParentId");

                    b.Property<string>("Remark");

                    b.Property<string>("RightsName");

                    b.Property<string>("RightsValue");

                    b.Property<int?>("Sort");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("User_Rights");
                });

            modelBuilder.Entity("Dtol.dtol.User_System", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("UserId");

                    b.Property<string>("UserPwd");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.ToTable("User_System");
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

                    b.Property<string>("tag");

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

            modelBuilder.Entity("Dtol.dtol.Except_Info_Employ", b =>
                {
                    b.HasOne("Dtol.dtol.UserFiles_Info", "UserFiles_Info")
                        .WithMany()
                        .HasForeignKey("UserFiles_InfoId");

                    b.HasOne("Dtol.dtol.facultystaff_Info", "facultystaff_Info")
                        .WithMany()
                        .HasForeignKey("facultystaff_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Except_Info_Student", b =>
                {
                    b.HasOne("Dtol.dtol.UserFiles_Info", "UserFiles_Info")
                        .WithMany()
                        .HasForeignKey("UserFiles_InfoId");

                    b.HasOne("Dtol.dtol.Student_Info", "student_Info")
                        .WithMany()
                        .HasForeignKey("student_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Health_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Student_Info", "Student_Info")
                        .WithMany("Health_Info")
                        .HasForeignKey("Student_InfoId");

                    b.HasOne("Dtol.dtol.Student_Info_Delete")
                        .WithMany("Health_Info")
                        .HasForeignKey("Student_Info_Deleteid");

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

            modelBuilder.Entity("Dtol.dtol.User_Relate_Info_Role", b =>
                {
                    b.HasOne("Dtol.dtol.Station_Info", "Station_Info")
                        .WithMany()
                        .HasForeignKey("Station_InfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany("User_Relate_Info_Role")
                        .HasForeignKey("User_InfoId")
                        .OnDelete(DeleteBehavior.Cascade);
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
