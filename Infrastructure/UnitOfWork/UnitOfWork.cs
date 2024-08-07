using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopStoreDbContext _context;

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(ShopStoreDbContext context, ICategoryRepository categoryRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IMemberRepository MemberRepository => _memberRepository;

        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public IProductRepository ProductRepository => _productRepository;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
