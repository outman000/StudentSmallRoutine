using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel
{
    public  class DayAndNightAddViewModel
    {
       public string idNumber { get; set; }
       public List<DayAndNightAddMiddle>  dayAndNightAddMiddles { get; set; }



    }
}
