using System;

namespace VegetableShop.Models
{
    public class Potato : Product
    {
        public double Count { get; set; }

        public Potato(double basePrice, double count) : base("Potato", basePrice)
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