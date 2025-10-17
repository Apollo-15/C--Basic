using System;
using VegetableShop.Service;

namespace VegetableShop.Models
{
    public class Carrot : Product
    {
        public double Count { get; set; }

        public Carrot(double basePrice, double count) : base("Carrot", basePrice)
        {
            this.Count = count;
        }

        public override double Price => BasePrice * Count;

        public override string ToString()
        {
            return $"{Name} — ${BasePrice}/lb * {Count} lbs = ${Price}";
        }
    }
}