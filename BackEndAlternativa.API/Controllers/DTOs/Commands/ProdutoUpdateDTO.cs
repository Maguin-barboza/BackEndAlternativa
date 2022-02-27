namespace BackEndAlternativa.API.Controllers.DTOs.Commands
{
    public class ProdutoUpdateDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Marca { get; set; }
        public int CategoriaId { get; set; }
    }
}
