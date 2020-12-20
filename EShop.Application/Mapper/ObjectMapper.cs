using AutoMapper;
using EShop.Application.Models;
using EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<EShopDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;

        public class EShopDtoMapper : Profile
        {
            public EShopDtoMapper()
            {
                CreateMap<Product, ProductModel>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();

                CreateMap<Order, OrderModel>().ReverseMap();

                CreateMap<OrderItem, OrderItemModel>().ReverseMap();
            }
        }
    }
}
