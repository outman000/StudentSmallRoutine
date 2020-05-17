using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IStatisticsService
    {
        List<EmployComtemlateMiddle> getBaseComtemplateInfoEmploy(BaseStudentStasticViewModel baseStudentStasticViewModel);
        List<StudentComtemlateMiddle> getBaseComtemplateInfo(BaseStudentStasticViewModel baseStudentStasticViewModel);
    }
}
