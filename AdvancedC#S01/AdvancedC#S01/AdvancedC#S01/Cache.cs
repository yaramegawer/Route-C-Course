using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_S01
{
    public class Cache<TKey, TValue>
    {
        private class CacheItem
        {
            public TValue Value { get; set; }
            public DateTime ExpirationTime { get; set; }
        }

        private readonly Dictionary<TKey, CacheItem> _cache = new();

        // Add with expiration in seconds
        public void Add(TKey key, TValue value, int expirationSeconds)
        {
            var item = new CacheItem
            {
                Value = value,
                ExpirationTime = DateTime.UtcNow.AddSeconds(expirationSeconds)
            };

            _cache[key] = item;
        }

        // Get value
        public TValue Get(TKey key)
        {
            if (!_cache.ContainsKey(key))
                throw new KeyNotFoundException("Key not found");

            var item = _cache[key];

            if (IsExpired(item))
            {
                _cache.Remove(key);
                throw new Exception("Item expired");
            }

            return item.Value;
        }

        // Remove item
        public bool Remove(TKey key)
        {
            return _cache.Remove(key);
        }

        // Check existence
        public bool Contains(TKey key)
        {
            if (!_cache.ContainsKey(key))
                return false;

            var item = _cache[key];

            if (IsExpired(item))
            {
                _cache.Remove(key);
                return false;
            }

            return true;
        }

        // Helper method
        private bool IsExpired(CacheItem item)
        {
            return DateTime.UtcNow > item.ExpirationTime;
        }
    }
}