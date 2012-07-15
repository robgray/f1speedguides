using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace atomicf1.common
{
    public static class CacheHelper
    {
        private static readonly ObjectCache Cache = MemoryCache.Default;

        public static T Get<T>(string key) where T : class
        {
            try
            {                
                return Cache.Contains(key) ? Cache[key] as T : null;                
            }
            catch
            {
                return null;
            }
        }

        public static void Insert(object objectToCache, string key)
        {
            if (objectToCache != null)
            {
                Cache.Add(key, objectToCache, DateTime.Now.AddDays(1));
            }
        }

        public static bool Contains(string key)
        {
            return Cache.Contains(key);
        }

        public static void Invalidate(string key)
        {
            Cache.Remove(key);
        }

        public static T Get<T>(string key, object objectToCache) where T : class
        {
            if (!Cache.Contains(key))
            {
                Insert(objectToCache, key);
            }
            return Get<T>(key);
        }

        public static void InvalidateAll()
        {
            List<KeyValuePair<String, Object>> cacheItems = (from n in Cache.AsParallel() select n).ToList();

            foreach (var a in cacheItems)
                Cache.Remove(a.Key);

        }
    }
}
