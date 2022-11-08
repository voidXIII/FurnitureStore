using Application.Dtos;
using Application.Helpers;
using Domain.Entities;
using Application.Specifications;

namespace API.Services
{
    public interface IProductService
    {
        Task<Pagination<ProductToReturnDto>> GetProductsAsync(ParamsSpecification paramsSpec);
        Task<ProductToReturnDto> GetProductWithSpecAsync(int id);
        Task<ProductToReturnDto> CreateProductAsync(ProductToCreateDto productToCreate);
        Task UpdateProductAsync(int id, ProductToUpdateDto productToUpdate);
        Task DeleteProductAsync(int id);
        Task<IReadOnlyList<Function>> GetAllFunctions();
        Task<IReadOnlyList<Topology>> GetAllTopologies();
    }
}