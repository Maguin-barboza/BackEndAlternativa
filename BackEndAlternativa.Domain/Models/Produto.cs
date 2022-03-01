using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAlternativa.Domain.Models
{
    public class Produto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("value")]
        public decimal Value { get; set; }
        [Column("brand")]
        public string Brand { get; set; }
        [Column("category_id")]
        public int Category_Id { get; set; }
        public Categoria Categoria { get; set; }
    }
}
