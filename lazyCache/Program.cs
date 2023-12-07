using System;

namespace lazyCache
{
    internal abstract class Program
    {
        private static void Main()
        {
            var productHandler = new ProductHandler();
            productHandler.InitReset();
            var product1 = productHandler.GetProduct("product-03");
            var product2 = productHandler.GetProduct("product-01");
            var product3 = productHandler.GetProduct("product-03");
            Console.WriteLine("Product Name : " + product1.Name + "    Product Price : " + product1.Price);
            Console.WriteLine("Product Name : " + product2.Name + "    Product Price : " + product2.Price);
            Console.WriteLine("Product Name : " + product3.Name + "    Product Price : " + product3.Price);
        }
    }
}
