using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel;
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Service.AutoMapper.SmallRoutine
{
    public class SmallRoutineMapper : Profile
    {
        public SmallRoutineMapper()
        {

            //CreateMap<PeopleUpdateViewModel, whiteList>();
            //CreateMap<whiteList, PeopleSearchMiddle>().ForMember(dest => dest.url,
            //    opts => opts.MapFrom(src => src.uploadFile.Url)); 

            CreateMap<FileUploadViewModel, UploadFile>();

            CreateMap<FileUploadViewModel, FileImgResViewModel>();

            CreateMap<GradeInfoServiceDTO, Grade_Info>(); 

            CreateMap<SchoolInfoServiceDTO, School_Info>();

            CreateMap<ClassInfoServiceDTO, Class_Info>();

            CreateMap<DepartInfoServiceDTO, Depart_Info>();

            CreateMap<StationInfoServiceDTO, Station_Info>();

            CreateMap<StationInfoServiceDTO, Station_Info>();//LoginValideReEmployesModel

            CreateMap<facultystaff_Info, ValideMiddleEmployMiddleModel>()
               .ForMember(a => a.studentRegisterHeathInfoViewModel, opt => opt.MapFrom(src => src.StudentRegisterHeath_Info))
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.IdNumber)));

            CreateMap<Student_Info, ValideMiddleViewModel>()
                 .ForMember(a => a.StudentRegisterHeathInfoViewModel, opt => opt.MapFrom(src => src.StudentRegisterHeath_Info))
                  .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.IdNumber)));

          

            CreateMap<Student_Info, User_Info>().ForMember(a=>a.id, opt => opt.Ignore());

            CreateMap<facultystaff_Info, User_Info>().ForMember(a => a.id, opt => opt.Ignore());

            CreateMap<LoginViewModel, LoginViewModel>()
                .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)))
                .ForMember(a => a.Password, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Password)))
                ;


            CreateMap<StudentRegisterHeath_Info, StudentRegisterHeathInfoViewModel>();
            CreateMap<StudentRegisterHeath_Info, HealthInfoSearchMiddle>()

                .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.Idnumber)));


            CreateMap<HealthInfoUpdateViewModel, StudentRegisterHeath_Info > ()
                 .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)));


            CreateMap<HealthInfoAddViewModel, StudentRegisterHeath_Info>()
                 .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)))
                 ;


            CreateMap<HealthEveryAddViewModel, Health_Info>()
                 .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));

            
            CreateMap< Health_Info, HealthEverySearchMiddleModel>()
                 .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.IdNumber)));

            CreateMap< HealthEveryUpdateViewModel, Health_Info >()
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));

            CreateMap<AddRelateFromStaffToClassViewModel, ClassManager_Relate>();
          

            CreateMap<Grade_Info, GradeInfoSearchMiddleModel>();
            CreateMap<Class_Info, ClassInfoSearchMiddleModel>()
                .ForMember(a => a.ClassCode, opt => opt.MapFrom(src => src.ClassCode))
           ;
           

            CreateMap<Health_Info, StaffClassMiddleModel>()
                 .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Student_Info.Name))
                .ForMember(a => a.GradeName, opt => opt.MapFrom(src => src.Student_Info.GradeCode))
                .ForMember(a => a.ClassName, opt => opt.MapFrom(src => src.Student_Info.ClassName))
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.IdNumber)));

            CreateMap<Health_Info, StaffStationMiddleModel>()
                 .ForMember(a => a.Name, opt => opt.MapFrom(src => src.facultystaff_Info.Name))
                  .ForMember(a => a.DepartName, opt => opt.MapFrom(src => src.facultystaff_Info.DepartName))
                .ForMember(a => a.StaffName, opt => opt.MapFrom(src => src.facultystaff_Info.StaffName))
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.IdNumber)));



            CreateMap<AddRelateFromStaffToStation, StaffStation_Relate>();
            CreateMap<Station_Info, StationInfoSearchMiddleModel>();


            CreateMap<StudentRegisterHeath_Info, StudentHealthInfoSearchMiddle>()
                .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.Idnumber)));


            CreateMap<StudentRegisterHeath_Info, EmployHealthInfoSearchMiddle>()
                .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.Idnumber)));





            CreateMap<Depart_Info, DepartInfoSearchMiddleModel>();


            CreateMap<Student_DayandNight_Info, DayandNightInfoMiddle>();

            CreateMap<DayAndNightUpdateViewModel, Student_DayandNight_Info>();


            CreateMap<ExceptStudentAddViewModel, Except_Info_Student>()
                 .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)));

            CreateMap<ExceptStudentUpdateViewModel, Except_Info_Student>()
                  .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash (src.Idnumber)));

            CreateMap<Except_Info_Student, ExceptStudentSearchMiddle>()
                 .ForMember(a => a.UserFiles_InfoId, opt => opt.MapFrom(src => src.UserFiles_Info.id))
                  .ForMember(a => a.Url, opt => opt.MapFrom(src => src.UserFiles_Info.Url))
                .ForMember(a => a.ClassName, opt => opt.MapFrom(src => src.student_Info.ClassName))
                  .ForMember(a => a.GradeName, opt => opt.MapFrom(src => src.student_Info.GradeName))
                .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.Idnumber)));


            CreateMap<ExceptEmployAddViewModel, Except_Info_Employ>()
                 .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)));

            CreateMap<Except_Info_Employ, ExceptEmploySearchMiddle>()
                  .ForMember(a => a.UserFiles_InfoId, opt => opt.MapFrom(src => src.UserFiles_Info.id))
                   .ForMember(a => a.Url, opt => opt.MapFrom(src => src.UserFiles_Info.Url))
                 .ForMember(a => a.StaffCode, opt => opt.MapFrom(src =>src.facultystaff_Info.StaffCode ))
                  .ForMember(a => a.DepartName, opt => opt.MapFrom(src => src.facultystaff_Info.DepartName))
                .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.Idnumber)));

            CreateMap<ExceptEmployUpdateViewModel, Except_Info_Employ>()
                  .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)));

            CreateMap<FileImageUploadViewModel, UserFiles_Info>()
                 .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)));



            CreateMap<School_Info, SchoolSearchMiddle>();


            CreateMap<Template_Student, StudentComtemlateMiddle>();
            CreateMap<Template_Employment, EmployComtemlateMiddle>();

        }
    }
}
