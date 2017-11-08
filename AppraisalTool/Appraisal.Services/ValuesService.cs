using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Appraisal.Core.Domain;
using Appraisal.Data;

namespace Appraisal.Services
{
    public class ValuesService : IValuesService
    {
        private readonly EFDbContext _db;
        public ValuesService(EFDbContext dbContext)
        {
            _db = dbContext;
        }
        public IEnumerable<Values> GetAllValues()
        {
            return _db.Values.ToList();
        }
    }
}
