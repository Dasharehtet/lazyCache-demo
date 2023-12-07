namespace lazyCache
{
    public class ProductHandler
    {
        private readonly ProductCache _productCache = new();

        public Product GetProduct(string id)
        {
            return _productCache.CheckCache(id);
        }
        public void InitReset()
        {
            _productCache.InitResetCache();
        }
    }
}