using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAlternativa.Domain.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Brand { get; set; }
        public CategoriaDTO Categoria { get; set; }
    }
}
