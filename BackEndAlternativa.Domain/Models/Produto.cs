using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAlternativa.Domain.Models
{
    public class Produto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("valor")]
        public decimal Valor { get; set; }
        [Column("marca")]
        public string Marca { get; set; }
        [Column("categoriaid")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
