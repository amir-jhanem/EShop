using AutoMapper;
using EShop.Application.Interfaces;
using EShop.Application.Mapper;
using EShop.Application.Models;
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

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }
    }
}
