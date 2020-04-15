using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
namespace Dto.Service.AutoMapper.SmallRoutine
{
    public class FacultystaffMapper : Profile
    {
        public FacultystaffMapper()
        {

            CreateMap<facultystaff_Info, FacultystaffBaseModel>();

            CreateMap<FacultystaffBaseModel, facultystaff_Info>()
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));

            CreateMap<FacultystaffSearchModel, FacultystaffSearchModel>()
               .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));


            CreateMap<facultystaff_Info, FacultystaffMiddle>();


            CreateMap<FacultystaffMiddle, facultystaff_Info>()
                .ForMember(a => a.IdNumber, opt => opt.MapFrom(src => Dtol.Helper.MD5.Md5Hash(src.IdNumber)));



        }
    }
}
