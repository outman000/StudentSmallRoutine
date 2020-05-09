using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IExceptEmployRepository : IRepository<Except_Info_Employ>
    {
        void deleteByList(List<int> deleteList);
        List<Except_Info_Employ> searchEmployinfo(ExceptEmploySearchViewModel exceptEmploySearchViewModel);
    }
}
