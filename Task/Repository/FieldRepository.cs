using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Repository
{
    public class FieldRepository:IFieldRepository
    {
        private readonly ArmyTechTaskEntities _db;

        public FieldRepository(ArmyTechTaskEntities db)
        {
            _db = db;
        }

        public IEnumerable<Field> getAll()
        {
            return _db.Fields;
        }
    }
}