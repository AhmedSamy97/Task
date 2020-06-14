using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Controllers;
using Task.Models;

namespace Task.Repository
{
   public interface IStudentRepository
   {
       void add(Student std);
       void Edit(CreateStudent stdData);
       void Delete(Student std);
       Student getByID(int id);
       IEnumerable<Student> getAll();
   }
}
