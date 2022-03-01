namespace BackEndAlternativa.API.Controllers.Models.Input
{
    public class ProdutoInput
    {
        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Descrição do Produto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Valor do Produto
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Marca do Produto
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// IdCategoria do Produto
        /// </summary>
        public int Category_Id { get; set; }
    }
}
