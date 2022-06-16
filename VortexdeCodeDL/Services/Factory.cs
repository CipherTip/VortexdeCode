using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VortexdeCodeDL.Data;
using VortexdeCodeDL.RepositoryBase;

namespace VortexdeCodeDL.Services
{
    internal class Factory
    {
        private readonly IDictionary<Type, Func<VortexDBContext, object>> _factoryCache;

        public Factory()
        {
            _factoryCache = new Dictionary<Type, Func<VortexDBContext, object>>();
        }

        public Func<VortexDBContext, object> GetRepositoryFactoryForEntityType<T>()
            where T : class
        {
            Func<VortexDBContext, object> factory = GetRepositoryFactoryFromCache<T>();
            if (factory != null)
            {
                return factory;
            }

            return DefaultEntityRepositoryFactory<T>();
        }

        public Func<VortexDBContext, object> GetRepositoryFactoryFromCache<T>()
        {
            Func<VortexDBContext, object> factory;
            _factoryCache.TryGetValue(typeof(T), out factory);
            return factory;
        }

        private Func<VortexDBContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new GenericRepositoryBase<T>(dbContext);
        }
    }
}
