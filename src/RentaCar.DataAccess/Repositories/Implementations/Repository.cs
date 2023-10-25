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

        public async Task<bool> CreateAsync(T entity)
        {
            var data = await Table.AddAsync(entity);

            return data.State == EntityState.Added;
        }

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

        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> expression)
            => await Table.Where(expression).FirstOrDefaultAsync();

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
          => await GetQuery().AnyAsync(expression);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public bool SoftDelete(T entity)
        { 
             entity.IsDeleted = true;
            return true;
        }

       
        public bool Update(T entity)
        {
            var data = Table.Update(entity);

            return data.State == EntityState.Modified;
        }
       


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
