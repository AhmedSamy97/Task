using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Repository
{
   public interface IStudentRepository
   {
       void add(Student std);
       void Edit(Student std);
       void Delete(Student std);
       Student getByID(int id);
       IEnumerable<Student> getAll();
   }
}
