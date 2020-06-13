using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ArmyTechTaskEntities db;

        public TeacherRepository(ArmyTechTaskEntities db)
        {
            this.db = db;
        }
        public IEnumerable<Teacher> getAll()
        {
            return db.Teachers.ToList();
        }
    }
}