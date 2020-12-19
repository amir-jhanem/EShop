using AutoMapper;
using EShop.Application.Interfaces;
using EShop.Application.Models;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class ProductPageService : IProductPageService
    {
        private readonly IProductService _productAppService;

        private readonly IMapper _mapper;

        public ProductPageService(IProductService productAppService, IMapper mapper)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                var list = await _productAppService.GetProductList();
                var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
                return mapped;
            }

            var listByName = await _productAppService.GetProductByName(productName);
            var mappedByName = _mapper.Map<IEnumerable<ProductViewModel>>(listByName);
            return mappedByName;
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var product = await _productAppService.GetProductById(id);
            var mapped= _mapper.Map<ProductViewModel>(product);
            return mapped;
        }

        public async Task Create(ProductViewModel product)
        {
            var mappedProductModel = _mapper.Map<ProductModel>(product);
            await _productAppService.Create(mappedProductModel);
        }

        public async Task Update(ProductViewModel product)
        {
            var mappedProductModel = _mapper.Map<ProductModel>(product);
            await _productAppService.Update(mappedProductModel);
        }

        public async Task Delete(ProductViewModel product)
        {
            var mappedProductModel = _mapper.Map<ProductModel>(product);
            await _productAppService.Delete(mappedProductModel);
        }
    }
}
