
using Domain.Entities;

namespace Application.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ParamsSpecification paramsSpec) : base(x =>
        (string.IsNullOrEmpty(paramsSpec.Search) || x.ProductName.ToLower().Contains(paramsSpec.Search)) &&
        (!paramsSpec.TopologyId.HasValue || x.TopologyId == paramsSpec.TopologyId) &&
        (!paramsSpec.FunctionId.HasValue || x.FunctionId == paramsSpec.FunctionId))
        {

        }
    }
}