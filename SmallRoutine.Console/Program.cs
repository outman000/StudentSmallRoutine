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
            studentComtemlateRepository.CompTemplateStudent();
           // employComtemplateRepository.CompTemplateEmploy();
            Console.WriteLine("当天计算成功\n");
            Console.WriteLine("输入任意键停止");
            Console.ReadLine();

        }
    }
}
