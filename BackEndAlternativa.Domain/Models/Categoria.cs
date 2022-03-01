using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAlternativa.Domain.Models
{
    public class Categoria
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}