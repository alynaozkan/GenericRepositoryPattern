using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Presentation.DataAccess.Context;
using Presentation.DataAccess.Repositories.Abstractions;
using Presentation.Entities.Abstract; //IEntity reference has been added
using System.Linq.Expressions;


namespace Presentation.DataAccess.Repositories.Concretes
{
    //ientity den türemis siniflar newlenebilir.
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly MyBlogDbContext _dbContext;

        public Repository(MyBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table { get => _dbContext.Set<T>(); }
        

        public async Task<int> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetbyIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=> Table.Update(entity));  
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetWithLazyLoadingAsync(Expression<Func< T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
             IQueryable<T> query = Table;

            // Direkt olarak filter'ı kullanıyoruz çünkü her zaman bir filtre uygulanacak.
            query = query.Where(filter);

            if (include!=null)
                query= include(query);

            T? entity = await query.FirstOrDefaultAsync();
            return entity;

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter =  null , params Expression<Func<T, object>>[] includeProperties )
        {
            IQueryable<T> query = Table;
            if (filter != null)
                query = query.Where(filter);

            if (includeProperties.Any() && includeProperties != null)
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.ToListAsync();
        }

    }
}
