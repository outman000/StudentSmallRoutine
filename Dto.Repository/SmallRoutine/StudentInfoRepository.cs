using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class StudentInfoRepository : IStudentInfoRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<School_Info> DbSet;

        public StudentInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<School_Info>();
        }
        #region 基本查询
        public void Add(School_Info obj)
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

        public IQueryable<School_Info> GetAll()
        {
            return DbSet;
        }

        public School_Info GetById(Guid id)
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

        public void Update(School_Info obj)
        {
            throw new NotImplementedException();
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


    }
}
