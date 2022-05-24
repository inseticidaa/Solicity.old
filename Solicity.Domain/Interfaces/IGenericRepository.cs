using Solicity.Domain.Entities;
using System.Linq.Expressions;

namespace Solicity.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(int id);

        Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<int> Add(T entity);

        Task Update(T entity);

        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();

        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}