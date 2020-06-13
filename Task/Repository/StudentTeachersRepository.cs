using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Repository
{
    public class StudentTeachersRepository:IStudentTeacherRespository
    {
        private readonly ArmyTechTaskEntities _db;

        public StudentTeachersRepository(ArmyTechTaskEntities db)
        {
            _db = db;
        }
        public void AddTeacherToStudent(StudentTeacher stdtTeacher)
        {
            _db.StudentTeachers.Add(stdtTeacher);
            _db.SaveChanges();
        }

        public IEnumerable<StudentTeacher> GetStudentTeachers(int stdId)
        {
            throw new NotImplementedException();
        }
    }
}