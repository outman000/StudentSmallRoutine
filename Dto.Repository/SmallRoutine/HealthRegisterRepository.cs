using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class HealthRegisterRepository : IHealthRegisterRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<StudentRegisterHeath_Info> DbSet;

        public HealthRegisterRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<StudentRegisterHeath_Info>();
        }

        public void Add(StudentRegisterHeath_Info obj)
        {
            DbSet.Add(obj);
        }

        public void DelByList(List<int> deleteList)
        {
            for (int i = 0; i < deleteList.Count; i++)
            {
                var model = DbSet.FirstOrDefault(w => w.id == deleteList[i]);
                DbSet.Remove(model);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<StudentRegisterHeath_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentRegisterHeath_Info GetById(int id)
        {
            return DbSet.FirstOrDefault(a => a.id == id);
        }

        public StudentRegisterHeath_Info GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return  Db.SaveChanges();
        }

        public List<StudentRegisterHeath_Info> searchHealthInfo(HealthInfoSearchViewModel healthInfoSearchViewModel)
        {
            int SkipNum = healthInfoSearchViewModel.pageViewModel.CurrentPageNum * healthInfoSearchViewModel.pageViewModel.PageSize;
            var preciate = SearchLineWhere(healthInfoSearchViewModel);
            return DbSet.Where(preciate)
                 .Skip(SkipNum)
                .Take(healthInfoSearchViewModel.pageViewModel.PageSize)
                 .OrderByDescending(o => o.CreateDate).ToList();
                

        }
    
        private Expression<Func<StudentRegisterHeath_Info, bool>> SearchLineWhere(HealthInfoSearchViewModel  healthInfoSearchViewModel)
        {
            var aa = DateTime.Now;

            var aaaaaaa = aa.ToString();

         
            var predicate = WhereExtension.True<StudentRegisterHeath_Info>();//初始化where表达式

          
            predicate = predicate.And(p => p.Idnumber.Trim().Contains(healthInfoSearchViewModel.Idnumber.Trim()==""?"":Dtol.Helper.MD5.Md5Hash(healthInfoSearchViewModel.Idnumber.Trim())));
            
           
            predicate = predicate.And(p => p.IsleaveJin.Contains(healthInfoSearchViewModel.IsleaveJin));
            predicate = predicate.And(p => p.IsPassHubei.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.PassHubeiDetail.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.Peers.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.PeersTelephone.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.Residencetemporary.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.Telephone.Contains(healthInfoSearchViewModel.Telephone));
            predicate = predicate.And(p => p.Temperature.Contains(healthInfoSearchViewModel.Temperature));
            predicate = predicate.And(p => p.Traffic.Contains(healthInfoSearchViewModel.Traffic));
            predicate = predicate.And(p => p.BackJinDate.ToString().Contains(healthInfoSearchViewModel.BackJinDate==null? "": healthInfoSearchViewModel.BackJinDate.Value.ToString("yyyy-MM-dd")));
            predicate = predicate.And(p => p.BeforeTianjin.Contains(healthInfoSearchViewModel.Traffic));
            predicate = predicate.And(p => p.Guardian.Contains(healthInfoSearchViewModel.Guardian));
            predicate = predicate.And(p => p.Destination.Contains(healthInfoSearchViewModel.Destination));
            predicate = predicate.And(p => p.ForteenDaysExcepting.Contains(healthInfoSearchViewModel.ForteenDaysExcepting));
            predicate = predicate.And(p => p.CreateDate.ToString().Contains(healthInfoSearchViewModel.CreateDate == null ? "" : healthInfoSearchViewModel.CreateDate.Value.ToString("yyyy-MM-dd")));



            // predicate = predicate.And(p => p.Id==lineSearchViewModel.Id);

            return predicate;
        }





        public void Update(StudentRegisterHeath_Info obj)
        {
            DbSet.Update(obj);
        }

        public StudentRegisterHeath_Info getByidNumber(string idnumber)
        {
           return  DbSet.FirstOrDefault(a => a.Idnumber== idnumber);
        }

        public List<StudentRegisterHeath_Info> searchHealthByStudentInfo(StudentSearchHealthInfo studentSearchHealthInfo)
        {
            List<StudentRegisterHeath_Info> studentRegisterHeath_Infos = new List<StudentRegisterHeath_Info>();
            var preciate = StudentSearchLineWhere(studentSearchHealthInfo);
            //需要从学生信息差
            var result= Db.Student_Info.Include(a => a.StudentRegisterHeath_Info).Where(preciate).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].StudentRegisterHeath_Info != null)
                {
                    studentRegisterHeath_Infos.Add(result[i].StudentRegisterHeath_Info);
                }
               
            }


            return studentRegisterHeath_Infos;

        }
        private Expression<Func<Student_Info, bool>> StudentSearchLineWhere(StudentSearchHealthInfo studentSearchHealthInfo)
        {
            var predicate = WhereExtension.True<Student_Info>();//初始化where表达式
            predicate = predicate.And(p => p.SchoolCode.Contains(studentSearchHealthInfo.SchoolCode));
            predicate = predicate.And(p => p.GradeCode.Contains(studentSearchHealthInfo.GradeCode));
            predicate = predicate.And(p => p.ClassCode.Contains(studentSearchHealthInfo.ClassCode));
            predicate = predicate.And(p => p.IdNumber .Contains(Dtol.Helper.MD5.Md5Hash(studentSearchHealthInfo.Idnumber)));
            predicate = predicate.And(p => p.Name  .Contains(studentSearchHealthInfo.Name));

            return predicate;
        }
        public List<StudentRegisterHeath_Info> searchHealthByEmployInfo(EmploySearchHealthInfo employSearchHealthInfo)
        {
            List<StudentRegisterHeath_Info> studentRegisterHeath_Infos = new List<StudentRegisterHeath_Info>();
            var preciate = EmploySearchLineWhere(employSearchHealthInfo);
            //需要从学生信息差
            var result = Db.facultystaff_Info.Include(a => a.StudentRegisterHeath_Info).Where(preciate).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].StudentRegisterHeath_Info != null)
                {
                    studentRegisterHeath_Infos.Add(result[i].StudentRegisterHeath_Info);
                }

            }


            return studentRegisterHeath_Infos;
        }
        private Expression<Func<facultystaff_Info, bool>> EmploySearchLineWhere(EmploySearchHealthInfo employSearchHealthInfo)
        {
            var predicate = WhereExtension.True<facultystaff_Info>();//初始化where表达式
            predicate = predicate.And(p => p.SchoolCode.Contains(employSearchHealthInfo.SchoolCode));
            predicate = predicate.And(p => p.StaffCode.Contains(employSearchHealthInfo.StaffCode));
            predicate = predicate.And(p => p.DepartCode.Contains(employSearchHealthInfo.DepartCode));
            predicate = predicate.And(p => p.IdNumber.Contains(Dtol.Helper.MD5.Md5Hash(employSearchHealthInfo.Idnumber)));
            predicate = predicate.And(p => p.Name.Contains(employSearchHealthInfo.Name));

            return predicate;
        }
    }
}
