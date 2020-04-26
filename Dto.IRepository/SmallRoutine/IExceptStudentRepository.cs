using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IExceptStudentRepository : IRepository<Except_Info_Student>
    {
        void deletebyList(List<int> deleteList);
        List<Except_Info_Student> searchByemploytoclass(ExceptStudengSearchInfoVIewModel exceptStudentSearchInfoVIewModel);
    }
}
