using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {

        IQueryable<T> GetAll();
        IQueryable<T> FindAll(Expression<Func<T,bool>> expression);
        Task<T> GetSingleAysnc(Expression<Func<T, bool>> expression);
        Task CreateAsync (T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete (T entity);
        Task<bool> IsExistAsyncI(Expression<Func<T, bool>> expression);
        Task<int> SaveAsync();
    }
}
