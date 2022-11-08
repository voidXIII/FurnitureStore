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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            _unitOfWork.Repository<Product>().Add(productToUpload);
            await _unitOfWork.Repository<Product>().SaveChangesAsync();
            return _mapper.Map<ProductToReturnDto>(productToUpload);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);

            if(product == null)
            {
                throw EntityNotFoundException.OfType<Product>(id);
            }
            await _unitOfWork.Repository<Product>().DeleteAsync(id);
            await _unitOfWork.Repository<Product>().SaveChangesAsync();
        }

        public async Task<Pagination<ProductToReturnDto>> GetProductsAsync(ParamsSpecification paramsSpec)
        {
            var spec = new ProductsWithTopologiesAndFunctionsSpecification(paramsSpec);
            var countSpec = new ProductWithFiltersForCountSpecification(paramsSpec);
            var products = await _unitOfWork.Repository<Product>().ListAsync(spec);
            var totalCount = await _unitOfWork.Repository<Product>().CountAsync(countSpec);
            var dataToReturn = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            return new Pagination<ProductToReturnDto>(paramsSpec.PageIndex, paramsSpec.PageSize, totalCount, dataToReturn);
        }

        public async Task<ProductToReturnDto> GetProductWithSpecAsync(int id)
        {
            var spec = new ProductsWithTopologiesAndFunctionsSpecification(id);
            var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);
            if(product == null)
            {
                throw EntityNotFoundException.OfType<Product>(id);
            }
            return _mapper.Map<ProductToReturnDto>(product);
        }

        public async Task UpdateProductAsync(int id, ProductToUpdateDto productToUpdate)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            if(product == null)
            {
                throw EntityNotFoundException.OfType<Product>(id);
            }
            var dataToUpdate = _mapper.Map(productToUpdate, product);
            _unitOfWork.Repository<Product>().Update(dataToUpdate);
            await _unitOfWork.Repository<Product>().SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Function>> GetAllFunctions()
        {
            return await _unitOfWork.Repository<Function>().ListAllAsync();
        }

        public async Task<IReadOnlyList<Topology>> GetAllTopologies()
        {
            return await _unitOfWork.Repository<Topology>().ListAllAsync();
        }
    }
}