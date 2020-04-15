using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.Service.AutoMapper.SmallRoutine
{
    public class StudentMapper: Profile
    {
        public StudentMapper()
        {

            CreateMap<Student_Info, StudentAddModel>();

            CreateMap<StudentAddModel, Student_Info>();
 

        }
    }
}
