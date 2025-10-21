using System;

namespace VegetableShop.Models
{
    public abstract class Product
    {
        public string Name { get; protected set; }
        protected double BasePrice { get; set; }
        public abstract double Price { get; }

        public Product(string name, double basePrice)
        {
            this.Name = name;
            this.BasePrice = basePrice;
        }

        public override string ToString()
        {
            return $"{Name} ${Price}";
        }
    }
}