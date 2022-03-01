using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAlternativa.Services.Utils.Exceptions
{
    public class DeleteCategoryWithProductsException: Exception
    {
        public DeleteCategoryWithProductsException(string? message) : base(message) {   }
    }
}
