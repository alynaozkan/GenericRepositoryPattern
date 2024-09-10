using Microsoft.EntityFrameworkCore.Query;
using Presentation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IEntity, new() 
    {
        Task<int> AddAsync(T entity);
        Task<T> GetWithLazyLoadingAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task <T> GetbyIdAsync(int id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null , params Expression<Func<T, object>>[] includeProperties );
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);


    }
}
