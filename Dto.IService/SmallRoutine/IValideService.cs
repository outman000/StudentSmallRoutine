using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IService.SmallRoutine
{
    public interface IValideService
    {
        StringBuilder ValideListDayAndNight<T>(List<Student_DayandNight_Info> sheet, String idnumber);

        StringBuilder ValideListDayAndNightOverRall<T>(List<Student_DayandNight_Info> sheet, String idnumber, StringBuilder stringBuilder);

        StringBuilder ValideListDayAndNightNum<T>(List<Student_DayandNight_Info> sheet, String idnumber, StringBuilder stringBuilder);

        StringBuilder ValideListDayAndNightNumIdInClass<T>(List<Student_DayandNight_Info> sheet, StringBuilder stringBuilder);
    }
}
