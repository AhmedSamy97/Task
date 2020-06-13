using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Repository
{
   public interface IGovernoratesRepository
   {
       IEnumerable<Governorate> getAll();
   }
}
