using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAlternativa.Domain.Results
{
    public class ResultOne<T> : ResultBase where T : class
    {
        public T? item { get; set; }
    }
}
