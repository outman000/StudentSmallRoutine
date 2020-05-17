using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IEmployComtemplateRepository
    {
        void CompTemplateEmploy();
        List<Template_Employment> GetCompTemplateEmploy(BaseStudentStasticViewModel baseStudentStasticViewModel);
    }
}
