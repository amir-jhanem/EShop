using EShop.Core.Entities;
using EShop.Core.Repositories;
using EShop.Infrastructure.Data;
using EShop.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
