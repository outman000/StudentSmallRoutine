using Dto.IRepository.SmallRoutine;
using Dto.Repository.SmallRoutine;
using SmallRoutineTiming.Implement;
using System;

namespace SmallRoutine.ConsoleGeneral
{
   public class Program
    {
        static void Main(string[] args)
        {
            var context = new ToolFactory();
            var timecontext = context.getDbContext();
            IStudentComtemlateRepository studentComtemlateRepository = new StudentComtemlateRepository(timecontext);
            IEmployComtemplateRepository employComtemplateRepository = new EmployComtemplateRepository(timecontext);

            //计算学生每日 每时段填报情况
            studentComtemlateRepository.CompTemplateStudent();
            //计算教职工 每 每时段填报情况
            employComtemplateRepository.CompTemplateEmploy();
         

        }
    }
}
