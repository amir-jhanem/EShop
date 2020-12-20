using AutoMapper;
using EShop.Application.Models;
using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Mapper
{
    public class EShopMapProfile : Profile
    {
        public EShopMapProfile()
        {
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<OrderModel, OrderViewModel>().ReverseMap();
            CreateMap<OrderItemModel, OrderItemViewModel>().ReverseMap();
        }
    }
}
