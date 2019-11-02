using Messege.CORE.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Messeger.BLL.Interfaces
{
    public interface IServiceRepository<T> where T:DefaultProperty
    {
        int Add(T entity);
        Task<int> AddAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        bool Delete(int entityID);
        Task<bool> DeleteAsync(int entityID);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        T Get(int entityID);
        Task<T> GetAsync(int entityID);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        ICollection<T> All();
        Task<List<T>> AllAsync();
        ICollection<T> All(Expression<Func<T, bool>> expression);
        Task<List<T>> AllAsync(Expression<Func<T, bool>> expression);
        void Save();
    }
}
