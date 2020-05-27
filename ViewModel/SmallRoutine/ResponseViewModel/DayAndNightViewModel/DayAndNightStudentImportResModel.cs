using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel
{
    public  class DayAndNightStudentImportResModel
    {
        public bool IsSuccess;
        public StringBuilder StringBuilder;

        public DayAndNightStudentImportResModel()
        {
            StringBuilder = new StringBuilder();
        }

    }
}
