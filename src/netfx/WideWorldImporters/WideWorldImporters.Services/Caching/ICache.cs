using System;

namespace WideWorldImporters.Services.Caching
{
    public interface ICache
    {
        T Get<T>(string key, Func<T> loader);
    }
}