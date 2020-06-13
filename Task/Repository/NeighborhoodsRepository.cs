using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Repository
{
    public class NeighborhoodsRepository : INeighborhoodsRepository
    {
        private readonly ArmyTechTaskEntities _db;

        public NeighborhoodsRepository(ArmyTechTaskEntities db)
        {
            _db = db;
        }
        public IEnumerable<Neighborhood> getAll()
        {
            return _db.Neighborhoods;
        }
    }
}