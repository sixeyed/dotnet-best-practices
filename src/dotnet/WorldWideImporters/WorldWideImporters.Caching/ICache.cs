using System;
using System.Threading.Tasks;

namespace WorldWideImporters.Caching
{
    public interface ICache
    {
        Task<T> GetAsync<T>(string key, Func<Task<T>> loader);
    }
}
