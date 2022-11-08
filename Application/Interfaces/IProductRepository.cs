using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<Topology>> GetTopologyAsync();
        Task<IReadOnlyList<Function>> GetFunctionsAsync();
    }
}