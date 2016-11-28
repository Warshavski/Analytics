using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Analytics.Web.Api.Models.Repositories;

namespace Analytics.Data.EntityFramework.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<TEntity> _set;

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region IRepository members

        public List<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Set.ToListAsync(cancellationToken);
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public async Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return await Set.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return await Set.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public TEntity FindById(object id)
        {
            return Set.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            return await Set.FindAsync(cancellationToken, id);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        #endregion IRepository members
        //---------------------------------------------------------------------
    }
}
