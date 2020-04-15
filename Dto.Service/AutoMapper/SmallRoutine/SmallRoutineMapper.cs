using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
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
               .ForMember(a => a.studentRegisterHeathInfoViewModel, opt => opt.MapFrom(src => src.StudentRegisterHeath_Info));

            CreateMap<Student_Info, ValideMiddleViewModel>()
                 .ForMember(a => a.StudentRegisterHeathInfoViewModel, opt => opt.MapFrom(src => src.StudentRegisterHeath_Info));

          

            CreateMap<Student_Info, User_Info>().ForMember(a=>a.id, opt => opt.Ignore());

            CreateMap<facultystaff_Info, User_Info>().ForMember(a => a.id, opt => opt.Ignore());

            CreateMap<LoginViewModel, LoginViewModel>()
                .ForMember(a => a.Idnumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Idnumber)))
                .ForMember(a => a.Password, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.Password)))
                ;

            CreateMap<StudentRegisterHeath_Info, StudentRegisterHeathInfoViewModel>();

            CreateMap<HealthInfoUpdateViewModel, StudentRegisterHeath_Info > ();

            CreateMap<StudentRegisterHeath_Info, HealthInfoSearchMiddle>();
      

        }
    }
}
