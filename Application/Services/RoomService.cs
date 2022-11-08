using Application.Dtos;
using Application.Errors;
using Application.Helpers;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Application.Specifications;
using API.Services;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Function> _functionRepo;
        private readonly IRepository<Topology> _topologyRepo;

        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> productRepo, IRepository<Function> functionRepo, IMapper mapper,
            IRepository<Topology> topologyRepo)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _functionRepo = functionRepo;
            _topologyRepo = topologyRepo;
        }
        public async Task<ProductToReturnDto> CreateProductAsync(ProductToCreateDto productToCreate)
        {
            var product = new Product
            {
                Model = productToCreate.Model,
                ProductName = productToCreate.ProductName,
                ImageUrl = productToCreate.ImageUrl,
                Price = productToCreate.Price,
                TopologyId = productToCreate.TopologyId,
                FunctionId = productToCreate.FunctionId,
                Dimensions = productToCreate.Dimensions,
                Description = productToCreate.Description
            };

            var productToUpload = _mapper.Map(productToCreate, product);
            _productRepo.Add(productToUpload);
            await _productRepo.SaveChangesAsync();
            return _mapper.Map<ProductToReturnDto>(productToUpload);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if(product == null)
            {
                throw EntityNotFoundException.OfType<Product>(id);
            }
            await _productRepo.DeleteAsync(id);
            await _productRepo.SaveChangesAsync();
        }

        public async Task<Pagination<ProductToReturnDto>> GetProductsAsync(ParamsSpecification paramsSpec)
        {
            var spec = new ProductsWithTopologiesAndFunctionsSpecification(paramsSpec);
            var countSpec = new ProductWithFiltersForCountSpecification(paramsSpec);
            var products = await _productRepo.ListAsync(spec);
            var totalCount = await _productRepo.CountAsync(countSpec);
            var dataToReturn = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            return new Pagination<ProductToReturnDto>(paramsSpec.PageIndex, paramsSpec.PageSize, totalCount, dataToReturn);
        }

        public async Task<ProductToReturnDto> GetProductWithSpecAsync(int id)
        {
            var spec = new ProductsWithTopologiesAndFunctionsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if(product == null)
            {
                throw EntityNotFoundException.OfType<Product>(id);
            }
            return _mapper.Map<ProductToReturnDto>(product);
        }

        public async Task UpdateProductAsync(int id, ProductToUpdateDto productToUpdate)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if(product == null)
            {
                throw EntityNotFoundException.OfType<Product>(id);
            }
            var dataToUpdate = _mapper.Map(productToUpdate, product);
            _productRepo.Update(dataToUpdate);
            await _productRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Function>> GetAllFunctions()
        {
            return await _functionRepo.ListAllAsync();
        }

        public async Task<IReadOnlyList<Topology>> GetAllTopologies()
        {
            return await _topologyRepo.ListAllAsync();
        }
    }
}