using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Repository
{
    public class GovernoratesRepository : IGovernoratesRepository
    {
        private readonly ArmyTechTaskEntities _db;

        public GovernoratesRepository(ArmyTechTaskEntities db)
        {
            _db = db;
        }
        public IEnumerable<Governorate> getAll()
        {
            return _db.Governorates;
        }
    }
}