using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Filter;

namespace BackEndAlternativa.API.Data.Repositories.Filters
{
    public class FilterProduto: ICustomQueryable, IQueryPaging
    {
        public int? Id { get; set; }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string? Nome { get; set; }
        [QueryOperator(Operator = WhereOperator.GreaterThanOrEqualTo, HasName = "Valor")]
        public decimal? ValorMin { get; set; }
        [QueryOperator(Operator = WhereOperator.LessThanOrEqualTo, HasName = "Valor")]
        public decimal? ValorMax { get; set; }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string? Marca { get; set; }
        public int? CategoriaId { get; set; }
        
        public int? Limit { get; set; } = 10;
        public int? Offset { get; set; }
    }
}
