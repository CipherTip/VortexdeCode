using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Data;
using VortexdeCodeDL.RepositoryBase;

namespace VortexdeCodeDL.Services
{
    internal class RepositoryServiceImpl : IRepositoryService
    {
        public VortexDBContext DbContext { get; set; }

        private readonly Factory _factory;
        protected Dictionary<Type, object> Repositories { get; private set; }

        public RepositoryServiceImpl()
        {
            _factory = new Factory();
            Repositories = new Dictionary<Type, object>();
        }

        public IGenericRepositoryBase<T> GetGenericRepository<T>() where T : class
        {
            Func<VortexDBContext, object> repositoryFactoryForEntityTypeDelegate = _factory.GetRepositoryFactoryForEntityType<T>();
            return GetCustomRepository<IGenericRepositoryBase<T>>(repositoryFactoryForEntityTypeDelegate);
        }

        public virtual T GetCustomRepository<T>(Func<VortexDBContext, object> factory = null) where T : class
        {
            object repository;
            Repositories.TryGetValue(typeof(T), out repository);
            if (repository != null)
            {
                return (T)repository;
            }
            return CreateRepository<T>(factory, DbContext);
        }

        private T CreateRepository<T>(Func<VortexDBContext, object> factory, VortexDBContext dbContext)
        {
            Func<VortexDBContext, object> repositoryFactory;
            if (factory != null)
            {
                repositoryFactory = factory;
            }
            else
            {
                repositoryFactory = _factory.GetRepositoryFactoryFromCache<T>();
            }
            if (repositoryFactory == null)
            {
                throw new NotSupportedException(typeof(T).FullName);
            }
            T repository = (T)repositoryFactory(dbContext);
            Repositories[typeof(T)] = repository;
            return repository;
        }
    }
}
