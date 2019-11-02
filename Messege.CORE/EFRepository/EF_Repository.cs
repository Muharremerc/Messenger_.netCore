using Messege.CORE.BaseClass;
using Messege.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Messege.CORE.EFRepository
{
    public class EF_Repository<T, DBContext> : EF_IRepository<T, DBContext> where T : DefaultProperty where DBContext : DbContext
    {

        private readonly DBContext _dbContext;
        public EF_Repository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity.ID;
        }

        public ICollection<T> All()
        {
            return _dbContext.Set<T>().ToList();
        }

        public ICollection<T> All(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).ToList();
        }

        public async Task<List<T>> AllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> AllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int entityID)
        {
            try
            {

                _dbContext.Set<T>().Remove(Get(entityID));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int entityID)
        {
            try
            {
                _dbContext.Set<T>().Remove(await GetAsync(entityID));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Get(int entityID)
        {
           return _dbContext.Set<T>().Where(x=>x.ID==entityID).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
           return _dbContext.Set<T>().Where(expression).FirstOrDefault();
        }

        public async Task<T> GetAsync(int entityID)
        {
           return await _dbContext.Set<T>().Where(x => x.ID == entityID).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
           return await _dbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public bool Update(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
