using System;

namespace VegetableShop.Models
{
    public class Cucumber : Product
    {
        public double Count { get; set; }

        public Cucumber(double basePrice, double count) : base("Cucumber", basePrice)
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