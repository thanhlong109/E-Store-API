using Infrastructure.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? pageIndex = 1, // Optional parameter for pagination (page number)
            int? pageSize = 20);

        Task AddAsync(T model);

        void AddAttach(T model);
        void AddEntry(T model);
        void Update(T model);
        void Remove(T model);

        void UpdateRange(List<T> models);

        Task AddRangeAsync(List<T> models);

        // Add paging method to generic interface 
        Task<Pagination<T>> ToPaginationAsync(int pageIndex = 0, int pageSize = 10);
        Task<Pagination<T>> ToListPaginationAsync(IQueryable<T> query, int pageIndex = 0, int pageSize = 10);
        Task<Pagination<T>> ToPaginationIncludeAsync(int pageIndex = 0, int pageSize = 10, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    }

}
