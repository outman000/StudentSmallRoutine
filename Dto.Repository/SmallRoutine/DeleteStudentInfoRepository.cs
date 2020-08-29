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
    public class DeleteStudentInfoRepository: IDeleteStudentInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Student_Info_Delete> DbSet;

        public DeleteStudentInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Student_Info_Delete>();
        }
        #region 基本查询
        public void Add(Student_Info_Delete obj)
        {
            DbSet.Add(obj);
        }

 

        public IQueryable<Student_Info_Delete> GetAll()
        {
            return DbSet;
        }
 

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(Student_Info_Delete obj)
        {
            DbSet.Update(obj);
        }
        #endregion

        public List<ClassInfoServiceDTO> GetClasslList()
        {
            return Db.Student_Info_Delete.Select(a => new ClassInfoServiceDTO
            {
                ClassCode = a.ClassCode,
                ClassName = a.ClassName
            }).Distinct().ToList();
        }

        public List<GradeInfoServiceDTO> GetGradeList()
        {
            return Db.Student_Info_Delete.Select(a => new GradeInfoServiceDTO
            {
                GradeCode = a.GradeCode,
                GradeName = a.GradeName

            }).Distinct().ToList();
        }

        public List<SchoolInfoServiceDTO> GetSchoolList()
        {
            return Db.Student_Info_Delete.Select(a => new SchoolInfoServiceDTO
            {
                SchoolCode = a.SchoolCode,
                SchoolName = a.SchoolName
            }).Distinct().ToList();
        }

        public List<SchoolInfoServiceDTO> GetIdNumberList()
        {
            return Db.Student_Info_Delete.Select(a => new SchoolInfoServiceDTO
            {
                SchoolCode = a.SchoolCode,
                SchoolName = a.SchoolName
            }).Distinct().ToList();
        }

   
        //根据id获取学生信息
        public Student_Info_Delete getbyID(int id)
        {
            Student_Info_Delete info = new Student_Info_Delete();

            //查询条件
            var predicate = WhereExtension.True<Student_Info_Delete>();//初始化where表达式
            predicate = predicate.And(p => p.Student_id.Equals(id));

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
        public void RemoveInfo(Student_Info_Delete info)
        {
            DbSet.Remove(info);
        }

 

        public Student_Info_Delete getByidNumber(string idnumber)
        {
            return DbSet.FirstOrDefault(a => a.IdNumber == idnumber);
        }
      
        public List<ClassInfoSearchMiddleModel> GetClasslListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            return Db.Student_Info_Delete.Where(a => a.SchoolCode == gradeAndClassSearchViewModel.SchoolCode).Select(a => new ClassInfoSearchMiddleModel
            {

                ClassCode = a.ClassCode,
                ClassName = a.ClassName
            }).Distinct().ToList();
        }

        public List<GradeInfoSearchMiddleModel> GetGradeListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            return Db.Student_Info_Delete.Where(a => a.SchoolCode == gradeAndClassSearchViewModel.SchoolCode).Select(a => new GradeInfoSearchMiddleModel
            {
                GradeCode = a.GradeCode,
                GradeName = a.GradeName

            }).Distinct().ToList();
        }

 
        public List<Student_Info_Delete> getAllClassByCode(string classCode)
        {
            return DbSet.Where(a => a.ClassCode == classCode).ToList();
        }

        public Student_Info_Delete GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
