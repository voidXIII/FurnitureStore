using Domain.Entities;

namespace Application.Specifications
{
    public class ProductsWithTopologiesAndFunctionsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTopologiesAndFunctionsSpecification(ParamsSpecification paramsSpec)
            : base (x =>
                (string.IsNullOrEmpty(paramsSpec.Search) || x.ProductName.ToLower().Contains(paramsSpec.Search.ToLower())) &&
                (!paramsSpec.TopologyId.HasValue || x.TopologyId == paramsSpec.TopologyId) &&  
                (!paramsSpec.FunctionId.HasValue || x.FunctionId == paramsSpec.FunctionId)        
            )
        {
            AddInclude(x => x.Topology);
            AddInclude(x => x.Function);
            AddOrderBy(x => x.ProductName);
            ApplyPaging(paramsSpec.PageSize * (paramsSpec.PageIndex), paramsSpec.PageSize);

            if(!string.IsNullOrEmpty(paramsSpec.Sort))
            {
                switch(paramsSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.ProductName);
                        break;
                }
            }
        }

        public ProductsWithTopologiesAndFunctionsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Topology);
            AddInclude(x => x.Function);
        }
    }
}