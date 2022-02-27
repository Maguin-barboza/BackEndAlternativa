using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace BackEndAlternativa.API.Data.Repositories.Filters
{
    public class FilterCategoria: ICustomQueryable
    {
        public int? Id { get; set; }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string? Nome { get; set; }
    }
}
