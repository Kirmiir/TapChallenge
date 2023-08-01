using Microsoft.Extensions.Logging;

namespace TapTest.Domain.Repositories
{
    public abstract class BaseRepository<TEntity> 
    {
        protected readonly List<TEntity> _entities;

        protected readonly ILogger _logger;

        protected BaseRepository(ILogger logger)
        {
            _entities = new List<TEntity>();
            _logger = logger;
        }

        public abstract TEntity Get(int id);

        public virtual List<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }
    }
}
