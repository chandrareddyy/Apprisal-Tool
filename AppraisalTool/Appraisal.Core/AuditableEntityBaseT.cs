using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal.Core
{
    public abstract class AuditableEntityBaseT<TId> : EntityBaseT<TId>
    {
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
