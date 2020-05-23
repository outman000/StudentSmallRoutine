using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel;
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public  interface IStaffClassRelateRepository : IRepository<ClassManager_Relate>
    {
        void RemoveByid(List<int> id);
        List<StaffClassMiddleModel> GetStudentsByStaff(StaffClassRelateSearchViewModel staffClassRelateSearchView);

        List<TeacherSearchClassMiddle> GetClassByTeacher(int UserKey);
        List<TeacherSearchClassAllMiddle> GetClassByTeacherAll(int userKeyId);
        bool isRepeat(AddRelateFromStaffToClassViewModel model);

        List<string> GetResponsibleClassByIdnumber(String idnumber);
        List<string> GetResponsibleGradeByIdnumber(String idnumber);

        int GetResponsibleClassPeopleNumber(String ClassCode);

    }
}
