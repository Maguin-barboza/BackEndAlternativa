using System.Collections.Generic;

namespace BackEndAlternativa.API.Controllers.DTOs.Queries
{
    public class CategoriaWithProdutosDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<ProdutoWithCategoriaDTO> Produtos { get; set; }
    }
}
