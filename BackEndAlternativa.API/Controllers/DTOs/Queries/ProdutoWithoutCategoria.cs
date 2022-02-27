namespace BackEndAlternativa.API.Controllers.DTOs.Queries
{
    public class ProdutoWithoutCategoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Marca { get; set; }
    }
}
