using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using WorldWideImporters.Caching.Options;
using memory = Microsoft.Extensions.Caching.Memory;

namespace WorldWideImporters.Caching
{
    public class MemoryCache : ICache
    {
        private readonly memory.MemoryCache _cache;
        private readonly CachingOptions _options;

        public MemoryCache(IOptions<CachingOptions> options)
        {
            _options = options.Value;
            _cache = new memory.MemoryCache(new memory.MemoryCacheOptions());
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> loader)
        {
            if (!_options.Enabled)
            {
                return await loader();
            }

            return await _cache.GetOrCreateAsync(key, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_options.SmallMemoryCache.DurationSeconds);
                return loader();
            });
        }
    }
}
