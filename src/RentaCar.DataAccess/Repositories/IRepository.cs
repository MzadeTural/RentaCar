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
        Task<bool> CreateAsync (T entity);
        bool Update(T entity);
        void Delete(T entity);
        bool SoftDelete (T entity);
       
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        Task<int> SaveAsync();
    }
}
