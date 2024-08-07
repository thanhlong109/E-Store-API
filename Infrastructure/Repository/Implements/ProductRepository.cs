using Doman.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implements
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopStoreDbContext context) : base(context)
        {
        }
    }
}
