using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class StudentInfoRepository : IStudentInfoRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<Student_Info> DbSet;

        public StudentInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Student_Info>();
        }
        #region 基本查询
        public void Add(Student_Info obj)
        {
            DbSet.Add(obj);
        }

        public void AddList(List<Student_Info> obj)
        {
            Db.Student_Info.AddRange(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student_Info> GetAll()
        {
            return DbSet;
        }

        public Student_Info GetById(Guid id)
        {
            throw new NotImplementedException();
        }

      

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(Student_Info obj)
        {
            DbSet.Update(obj);
        }
        #endregion

        public List<ClassInfoServiceDTO> GetClasslList()
        {
            return Db.Student_Info.Select(a => new ClassInfoServiceDTO {
                 ClassCode = a.ClassCode,
                 ClassName=a.ClassName
            }).Distinct().ToList();
        }

        public List<GradeInfoServiceDTO> GetGradeList()
        {
            return Db.Student_Info.Select(a => new GradeInfoServiceDTO
            {
                GradeCode = a.GradeCode,
                 GradeName=a.GradeName

            }).Distinct().ToList();
        }

        public List<SchoolInfoServiceDTO> GetSchoolList()
        {
            return Db.Student_Info.Select(a => new SchoolInfoServiceDTO
            {
                SchoolCode=a.SchoolCode,
                SchoolName=a.SchoolName
            }).Distinct().ToList();
        }

        public List<SchoolInfoServiceDTO> GetIdNumberList()
        {
            return Db.Student_Info.Select(a => new SchoolInfoServiceDTO
            {
                SchoolCode = a.SchoolCode,
                SchoolName = a.SchoolName
            }).Distinct().ToList();
        }

        public Student_Info GetStudentInfoAndHealthInfo(string Idnumber)
        {
            return DbSet.Where(a => a.IdNumber == Idnumber).Include(a=>a.StudentRegisterHeath_Info).FirstOrDefault();
          
        }



        //根据id获取学生信息
        public Student_Info getbyID(int id)
        {
            Student_Info info = new Student_Info();

            //查询条件
            var predicate = WhereExtension.True<Student_Info>();//初始化where表达式
            predicate = predicate.And(p => p.id.Equals(id));

            var result = DbSet.Where(predicate).ToList();
            if (result.Count > 0)
            {
                info = result.First();
            }
            else
            {
                info = null;
            }

            return info;
        }

        //删除信息
        public void RemoveInfo(Student_Info info)
        {
            DbSet.Remove(info);
        }


        //根据条件查询
        public List<Student_Info> GetByModel(StudentSearchModel model)
        {
            //查询条件
            var predicate = WhereExtension.True<Student_Info>();//初始化where表达式
                                                                //姓名
            if (!String.IsNullOrEmpty(model.Name))
            {
                predicate = predicate.And(p => p.Name.Contains(model.Name));
            }
            //身份证
            if (!String.IsNullOrEmpty(model.IdNumber))
            {
                predicate = predicate.And(p => p.IdNumber.Equals(model.IdNumber));
            }
            //学校
            if (!String.IsNullOrEmpty(model.SchoolCode))
            {
                predicate = predicate.And(p => p.SchoolCode.Equals(model.SchoolCode));
            }
            //年级
            if (!String.IsNullOrEmpty(model.GradeCode))
            {
                predicate = predicate.And(p => p.GradeCode.Equals(model.GradeCode));
            }
            //班级
            if (!String.IsNullOrEmpty(model.ClassCode))
            {
                predicate = predicate.And(p => p.ClassCode.Equals(model.ClassCode));
            }
            //住址
            if (!String.IsNullOrEmpty(model.PermanentAddress))
            {
                predicate = predicate.And(p => p.PermanentAddress.Contains(model.PermanentAddress));
            }
            var result = DbSet.Where(predicate).ToList();


            return result;
        }

        public Student_Info getByidNumber(string idnumber)
        {
            return DbSet.FirstOrDefault(a => a.IdNumber== idnumber);
        }
        //写错地方了。。。。。就这样吧
        public List<ClassInfoSearchMiddleModel> GetClasslListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
             return Db.Student_Info.Where(a=>a.SchoolCode== gradeAndClassSearchViewModel.SchoolCode).Select(a => new ClassInfoSearchMiddleModel
             {
                
                ClassCode = a.ClassCode,
                ClassName = a.ClassName
            }).Distinct().ToList();
        }

        public List<GradeInfoSearchMiddleModel> GetGradeListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            return Db.Student_Info.Where(a => a.SchoolCode == gradeAndClassSearchViewModel.SchoolCode).Select(a => new GradeInfoSearchMiddleModel
            {
               
                GradeCode = a.GradeCode,
                GradeName = a.GradeName

            }).Distinct().ToList();
        }
    }
}
