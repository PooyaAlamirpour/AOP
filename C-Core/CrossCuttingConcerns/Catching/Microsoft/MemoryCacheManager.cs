using System;
using Core.IoC;
using Microsoft.Extensions.Caching.Memory;

namespace Core.CrossCuttingConcerns.Catching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheManager()
        {
            _cache = ServiceTools.Resolve<IMemoryCache>();
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Add(string key, object data, int duration)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        
    }
}