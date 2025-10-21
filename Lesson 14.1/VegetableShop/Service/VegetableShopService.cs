using System;
using VegetableShop.Models;

namespace VegetableShop.Service
{
    public class VegetableShopService
    {
        private readonly List<Product> allProducts = new List<Product>();

        public void AddProducts(IEnumerable<Product> products)
        {
            allProducts.AddRange(products);
        }

        public void PrintProductsInfo()
        {
            double total = 0;
            System.Console.WriteLine("Products in the store: ");
            foreach (var product in allProducts)
            {
                System.Console.WriteLine(product);
                total += product.Price;
            }

            System.Console.WriteLine($"\nTotal cost of all products: ${total}");
        }
    }
}