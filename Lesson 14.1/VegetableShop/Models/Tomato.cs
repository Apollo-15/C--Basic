using System;

namespace VegetableShop.Models
{
    public class Tomato : Product
    {
        public double Count { get; set; }

        public Tomato(double basePrice, double count) : base("Tomato", basePrice)
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