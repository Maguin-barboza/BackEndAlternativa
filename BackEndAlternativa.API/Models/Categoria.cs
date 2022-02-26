using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAlternativa.API.Models
{
    public class Categoria
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }

        public IEnumerable<Produto> produtos { get; set; }
    }
}