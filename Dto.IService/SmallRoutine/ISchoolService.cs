using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface ISchoolService
    {
        List<SchoolSearchMiddle> getschoolInfo();
    }
}
