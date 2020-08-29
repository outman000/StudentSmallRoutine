using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.Service.AutoMapper.SmallRoutine
{
    public class StudentMapper: Profile
    {
        public StudentMapper()
        {

            CreateMap<Student_Info, StudentBaseModel>();

            CreateMap<StudentBaseModel, Student_Info>()
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));

            CreateMap<StudentSearchModel, StudentSearchModel>()
               .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));


            //CreateMap<Student_Info, StudentMiddle>()
            //   .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Decrypt(src.IdNumber,"test")));

            CreateMap<Student_Info, StudentMiddle>();


            CreateMap<StudentMiddle, Student_Info>()
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));

            CreateMap<Student_Info, Student_Info_Delete>();
            CreateMap<Student_Info_Delete, Student_Info>();

        }
    }
}
