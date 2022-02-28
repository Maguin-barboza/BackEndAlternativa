using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAlternativa.Domain.Results
{
    public class ResultMany<T>: ResultBase where T : class
    {
        public IEnumerable<T>? items { get; set; }
    }
}
