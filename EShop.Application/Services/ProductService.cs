using AutoMapper;
using EShop.Application.Interfaces;
using EShop.Application.Mapper;
using EShop.Application.Models;
using EShop.Core.Entities;
using EShop.Core.Interfaces;
using EShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IAppLogger<ProductService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var mapped = ObjectMapper.Mapper.Map<ProductModel>(product);
            return mapped;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<ProductModel> Create(ProductModel productModel)
        {
            await ValidateProductIfExist(productModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Product>(productModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _productRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ProductModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(ProductModel productModel)
        {
            ValidateProductIfNotExist(productModel);

            var editProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (editProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<ProductModel, Product>(productModel, editProduct);

            await _productRepository.UpdateAsync(editProduct);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(ProductModel productModel)
        {
            ValidateProductIfNotExist(productModel);
            var deletedProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (deletedProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _productRepository.DeleteAsync(deletedProduct);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateProductIfExist(ProductModel productModel)
        {
            var existingEntity = await _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{productModel} with this id already exists");
        }

        private void ValidateProductIfNotExist(ProductModel productModel)
        {
            var existingEntity = _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{productModel} with this id is not exists");
        }
    }
}
