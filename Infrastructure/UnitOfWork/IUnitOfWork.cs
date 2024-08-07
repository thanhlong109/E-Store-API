using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IMemberRepository MemberRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }

        public Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
