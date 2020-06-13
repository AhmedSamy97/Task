using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Controllers
{
    public class CreateStudent
    {
        public Student Student { get; set; }
        public IEnumerable<int> TeacherId { get; set; }
    }
}