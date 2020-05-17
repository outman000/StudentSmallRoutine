using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public  interface IStudentComtemlateRepository
    {
        void CompTemplateStudent();
        List<Template_Student> GetCompTemplateStudent(BaseStudentStasticViewModel baseStudentStasticViewModel);
    }
}
