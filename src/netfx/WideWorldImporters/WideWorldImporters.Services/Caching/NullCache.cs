using System;

namespace WideWorldImporters.Services.Caching
{
    public class NullCache : ICache
    {
        public T Get<T>(string key, Func<T> loader)
        {
            return loader();
        }
    }
}