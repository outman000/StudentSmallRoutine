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
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class DayandNightRepository : IDayandNightRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Student_DayandNight_Info> DbSet;

        public DayandNightRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Student_DayandNight_Info>();
        }

        public void Add(Student_DayandNight_Info obj)
        {
            DbSet.Add(obj);
        }

        public void AddList(List<Student_DayandNight_Info> obj)
        {
            //for (int i = 0; i < obj.Count; i++)
            //{
            //    if (DbSet.FirstOrDefault(a => a.IdNumber == obj[i].IdNumber
            //                                 && a.AddTimeInterval == obj[i].AddTimeInterval
            //                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == obj[i].AddCreateDate.Value.ToString("yyyy-MM-dd")
            //                                )) 
            //}


            DbSet.AddRange(obj);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student_DayandNight_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student_DayandNight_Info GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveList(List<int> ids)
        {
            for (int i = 0; i < ids.Count(); i++)
            {
                var deletemodel = DbSet.FirstOrDefault(a => a.id == ids[i]);

                DbSet.Remove(deletemodel);
            }
        }


        public List<Student_DayandNight_Info> SearchDayAndNightList(DayAndNightSearchViewModel dayAndNightSearchViewModel)
        {
            var preciate = GetByModelWhere(dayAndNightSearchViewModel);
            var precateresult = GetByModelChildResultWhere(dayAndNightSearchViewModel);
            List<Student_DayandNight_Info> Student_DayandNight_Infos = new List<Student_DayandNight_Info>();
            if (dayAndNightSearchViewModel.RoleID.Equals("sys"))
            {
                var tempresult = Db.Student_DayandNight_Info.Where(preciate);
                Student_DayandNight_Infos.AddRange(tempresult.ToList());
            }
            else
            {
                var searchResult = Db.ClassManager_Relate
                    .Where(a => a.facultystaff_InfoId == dayAndNightSearchViewModel.userKey)
                    .Include(a => a.Class_Info).ToList();

                for (int i = 0; i < searchResult.Count; i++)
                {
                    if (searchResult[i].Class_Info == null || searchResult[i].Class_Info.ClassCode.Equals("string") || searchResult[i].Class_Info.ClassCode.Equals(""))
                    {
                        continue;
                    }
                    var gradeName = int.Parse(searchResult[i].Class_Info.ClassCode.Substring(2, 2)).ToString();
                    var className = int.Parse(searchResult[i].Class_Info.ClassCode.Substring(4, 2)).ToString();
                    var preciatechild = GetByModelChildWhere(className, gradeName);
                    var tempresult = Db.Student_DayandNight_Info.Where(preciate);
                    tempresult = tempresult.Where(preciatechild);
                    //.Where(a => a.SchoolName == dayAndNightSearchViewModel.SchoolName
                    //  && a.GradeName == gradeName
                    //   && a.ClassName == dayAndNightSearchViewModel.ClassName
                    //).ToList();

                    Student_DayandNight_Infos.AddRange(tempresult.ToList());
                }
            }



            return Student_DayandNight_Infos.AsQueryable().Where(precateresult).OrderByDescending(a => a.AddCreateDate).ToList();
            //return Student_DayandNight_Infos.AsQueryable().Where(precateresult).ToList();
        }
        public List<Student_DayandNight_Info> CheckDayAndNightList(DayAndNightCheckViewModel dayAndNightSearchViewModel)
        {
            var preciate = GetByModelWherecheck(dayAndNightSearchViewModel);
            var precateresult = GetByModelChildResultWherecheck(dayAndNightSearchViewModel);

            var searchResult = Db.ClassManager_Relate
          .Where(a => a.facultystaff_InfoId == dayAndNightSearchViewModel.userKey)
          .Include(a => a.Class_Info).ToList();

            List<Student_DayandNight_Info> Student_DayandNight_Infos = new List<Student_DayandNight_Info>();
            for (int i = 0; i < searchResult.Count(); i++)
            {


                var gradeName = int.Parse(searchResult[i].Class_Info.ClassCode.Substring(2, 2)).ToString();
                var className = int.Parse(searchResult[i].Class_Info.ClassCode.Substring(4, 2)).ToString();
                var preciatechild = GetByModelChildWhere(className, gradeName);
                var tempresult = Db.Student_DayandNight_Info.Where(preciate);
                tempresult = tempresult.Where(preciatechild);
                //.Where(a => a.SchoolName == dayAndNightSearchViewModel.SchoolName
                //  && a.GradeName == gradeName
                //   && a.ClassName == dayAndNightSearchViewModel.ClassName
                //).ToList();

                Student_DayandNight_Infos.AddRange(tempresult.ToList());
            }



            return Student_DayandNight_Infos.AsQueryable().Where(precateresult).ToList();
        }

        public Expression<Func<Student_DayandNight_Info, bool>> GetByModelWhere(DayAndNightSearchViewModel dayAndNightSearchViewModel)
        {
            var predicate = WhereExtension.True<Student_DayandNight_Info>();//初始化where表达式SchoolName
                                                                            //姓          
            predicate = predicate.And(p => p.GradeName.Contains(dayAndNightSearchViewModel.GradeName));
            predicate = predicate.And(p => p.ClassName.Contains(dayAndNightSearchViewModel.ClassName));
            predicate = predicate.And(p => p.IsComeSchool.Contains(dayAndNightSearchViewModel.IsComeSchool));
            predicate = predicate.And(p => p.Name.Contains(dayAndNightSearchViewModel.Name));
            predicate = predicate.And(p => p.SchoolName.Contains(dayAndNightSearchViewModel.SchoolName));
            predicate = predicate.And(p => p.Temperature.Contains(dayAndNightSearchViewModel.Temperature));
            predicate = predicate.And(p => p.AddTimeInterval.Contains(dayAndNightSearchViewModel.AddTimeInterval));
            
            if (dayAndNightSearchViewModel.AddCreateDate != null && !dayAndNightSearchViewModel.AddCreateDate.Equals("") && dayAndNightSearchViewModel.AddCreateDateT != null && !dayAndNightSearchViewModel.AddCreateDateT.Equals(""))
            {
                predicate = predicate.And(p => p.AddCreateDate >= Convert.ToDateTime(Convert.ToDateTime(dayAndNightSearchViewModel.AddCreateDate).ToString("yyyy-MM-dd 00:00:00")) && p.AddCreateDate <= Convert.ToDateTime(Convert.ToDateTime(dayAndNightSearchViewModel.AddCreateDateT).ToString("yyyy-MM-dd 23:59:59")));//hc加日期条件
            }
            predicate = predicate.And(p => p.tag.Contains(dayAndNightSearchViewModel.tag));


            return predicate;
        }
        public Expression<Func<Student_DayandNight_Info, bool>> GetByModelWherecheck(DayAndNightCheckViewModel dayAndNightSearchViewModel)
        {
            var predicate = WhereExtension.True<Student_DayandNight_Info>();//初始化where表达式SchoolName
                                                                            //姓          
            predicate = predicate.And(p => p.GradeName.Contains(dayAndNightSearchViewModel.GradeName));
            predicate = predicate.And(p => p.IsComeSchool.Contains(dayAndNightSearchViewModel.IsComeSchool));
            predicate = predicate.And(p => p.Name.Contains(dayAndNightSearchViewModel.Name));
            predicate = predicate.And(p => p.SchoolName.Contains(dayAndNightSearchViewModel.SchoolName));
            predicate = predicate.And(p => p.Temperature.Contains(dayAndNightSearchViewModel.Temperature));
            predicate = predicate.And(p => p.AddTimeInterval.Contains(dayAndNightSearchViewModel.AddTimeInterval));
            if (dayAndNightSearchViewModel.AddCreateDate != null && !dayAndNightSearchViewModel.AddCreateDate.Equals(""))
            {
                predicate = predicate.And(p => p.AddCreateDate >= Convert.ToDateTime(Convert.ToDateTime(dayAndNightSearchViewModel.AddCreateDate).ToString("yyyy-MM-dd 00:00:00")) && p.AddCreateDate <= Convert.ToDateTime(Convert.ToDateTime(dayAndNightSearchViewModel.AddCreateDate).ToString("yyyy-MM-dd 23:59:59")));
            }


            predicate = predicate.And(p => p.tag.Contains(dayAndNightSearchViewModel.tag));


            return predicate;
        }
        public Expression<Func<Student_DayandNight_Info, bool>> GetByModelChildWhere(String ClassName, String GradeName)
        {
            var predicate = WhereExtension.True<Student_DayandNight_Info>();//初始化where表达式SchoolName
            predicate = predicate.And(p => p.GradeName == int.Parse(GradeName).ToString());
            predicate = predicate.And(p => p.ClassName == int.Parse(ClassName).ToString());
            return predicate;
        }



        public Expression<Func<Student_DayandNight_Info, bool>> GetByModelChildResultWhere(DayAndNightSearchViewModel dayAndNightSearchViewModel)
        {
            var predicate = WhereExtension.True<Student_DayandNight_Info>();//初始化where表达式SchoolName
            if (dayAndNightSearchViewModel.GradeName != "")
            {
                predicate = predicate.And(p => p.GradeName == dayAndNightSearchViewModel.GradeName);
            }
            if (dayAndNightSearchViewModel.ClassName != "")
            {
                predicate = predicate.And(p => p.ClassName == dayAndNightSearchViewModel.ClassName);
            }

            return predicate;
        }
        public Expression<Func<Student_DayandNight_Info, bool>> GetByModelChildResultWherecheck(DayAndNightCheckViewModel dayAndNightSearchViewModel)
        {
            var predicate = WhereExtension.True<Student_DayandNight_Info>();//初始化where表达式SchoolName
            if (dayAndNightSearchViewModel.GradeName != "")
            {
                predicate = predicate.And(p => p.GradeName == dayAndNightSearchViewModel.GradeName);
            }
            if (dayAndNightSearchViewModel.ClassName != "")
            {
                predicate = predicate.And(p => p.ClassName == dayAndNightSearchViewModel.ClassName);
            }

            return predicate;
        }
        //public int GetComeSchoolCount()
        //{
        //    DbSet.Where(a=>a.IsComeSchool=="是")

        //    return 0;
        //}



        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(Student_DayandNight_Info obj)
        {
            DbSet.Update(obj);
        }

        public List<Student_DayandNight_Info> getInfoByTag(string tag)
        {
            return DbSet.Where(a => a.tag == tag).ToList();
        }

        public void deleteRange(List<Student_DayandNight_Info> list)
        {
            DbSet.RemoveRange(list);
        }
    }
}
