using Appraisal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal.Services
{
     public interface IValuesService
    {
        IEnumerable<Values> GetAllValues();
    }
}
