using System;
using WideWorldImporters.Services.Config;
using runtime = System.Runtime.Caching;

namespace WideWorldImporters.Services.Caching
{
    public class MemoryCache : ICache
    {
        private readonly IConfig _config;
        private readonly runtime.MemoryCache _cache = new runtime.MemoryCache("WideWorldImporters.Services.Caching.MemoryCache");

        public MemoryCache(IConfig config)
        {
            _config = config;
        }

        public T Get<T>(string key, Func<T> loader)
        {
            if (!_cache.Contains(key))
            {
                _cache.Add(key, loader(), DateTimeOffset.UtcNow.AddSeconds(_config.CacheDurationSeconds));
            }
            return (T)_cache.GetCacheItem(key).Value;
        }
    }
}