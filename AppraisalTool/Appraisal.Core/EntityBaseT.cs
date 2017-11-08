using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal.Core
{
    [Serializable]
    public abstract class EntityBaseT<TId>
    {
        public EntityBaseT() : this(default(TId))
        {

        }

        public EntityBaseT(TId id)
        {
            Id = id;
        }
        
        public TId Id { get; set; }
    }
}
