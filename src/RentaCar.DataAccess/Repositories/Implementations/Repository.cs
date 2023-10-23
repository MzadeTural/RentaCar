using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities.Common;
using RentaCar.DataAccess.Contexts;
using System.Linq.Expressions;

namespace RentaCar.DataAccess.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly RentaCarContext _context;

        public Repository(RentaCarContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
         => Table.AsQueryable();

        public Task<T> GetSingleAysnc(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExistAsyncI(Expression<Func<T, bool>> expression)
          => await GetQuery().AnyAsync(expression);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public void SoftDelete(T entity)
            => entity.IsDeleted = true;

        public void Update(T entity)
          => Table.Update(entity);


        private IQueryable<T> GetQuery(params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query.Include(item);
                }
            }
            return query;
        }
    }
}
