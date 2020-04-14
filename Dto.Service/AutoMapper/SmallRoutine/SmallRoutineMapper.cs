using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
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

        }
    }
}
