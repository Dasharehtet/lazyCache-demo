using System.Collections.Generic;
using LazyCache;
using LazyCache.Providers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace lazyCache
{
    public class ProductCache
    {
        private IAppCache _cache = new CachingService();
        private List<Product> _dummyData = new();

        public void InitResetCache()
        {
            _cache.CacheProvider.Dispose();
            var provider = new MemoryCacheProvider(
                new MemoryCache(
                    new MemoryCacheOptions()));
            _cache = new CachingService(provider);
            _dummyData = new List<Product>
            {
                new("product-01", "High Back Leather Chair", 34475.00m),
                new("product-02", "Mid Back Leather Chair", 24475.00m),
                new("product-03", "Low Back Leather Chair", 14475.00m),
                new("product-04", "Visitor Chair", 24400.00m),
                new("product-05", "Lecture hall chair", 7475.00m)
            };
        }
        public Product CheckCache(string productId)
        {
            Func<Product> loadedProduct = () => LoadProduct(productId);
            var cachedResult = _cache.GetOrAdd(productId,
                loadedProduct, DateTimeOffset.UtcNow.AddMinutes(15));
            return cachedResult;
        }

        private Product LoadProduct(string productId)
        {
            return _dummyData.FirstOrDefault(p => p.Id == productId);
        }
    }
}