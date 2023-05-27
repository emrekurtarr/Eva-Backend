using Microsoft.EntityFrameworkCore;
using SuperTraders.DAL.Repository.Interfaces.EntityFramework.BaseRepos;
using SuperTraders.Entities.Base;
using System.Linq.Expressions;

namespace SuperTraders.DAL.Repository.Implementation.EntityFramework
{
    public class GenericBaseEFRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {

        protected readonly EFDbContext _dbContext;
        private readonly DbSet<T> _dbSet;


        public GenericBaseEFRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _dbContext.SaveChanges();

        }

        public async Task<int> DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            List<T> result = predicate == null ? _dbSet.ToList() : _dbSet.Where(predicate).ToList();

            return result;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsyncAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            List<T> result =  predicate == null ? await _dbSet.ToListAsync() : await _dbSet.Where(predicate).ToListAsync();

            return result;
        }

        public T Update(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

    }
}
