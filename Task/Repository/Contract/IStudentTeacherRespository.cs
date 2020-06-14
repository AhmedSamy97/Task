using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Repository
{
   public interface IStudentTeacherRespository
   {
      void AddTeacherToStudent(StudentTeacher stdtTeacher);
      IEnumerable<int> GetStudentTeachers(int stdId);
   }
}
