using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeService.Repositories.Abstractions
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindByIdAsync(int id);
        Task<T> FindByIdAsync(string id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
        Task SaveAsync();
    }
}
