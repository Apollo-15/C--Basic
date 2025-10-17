using System;
using System.Collections.Generic;
using VegetableShop.Models;
using VegetableShop.Service;

namespace VegetableShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>()
            {
                new Carrot(2.0, 5),
                new Potato(1.2, 10),
                new Tomato(3.0, 4),
                new Cucumber(2.0, 3)
            };

            VegetableShopService shop = new VegetableShopService();
            shop.AddProducts(products);
            shop.PrintProductsInfo();
        }
    }
}
