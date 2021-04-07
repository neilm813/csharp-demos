using System;

namespace OOPAbstractAndInterface
{
    public class Bunker : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }
        private bool isShielded { get; set; }

        public Bunker(string name)
        {
            Name = name;
            Health = 300;
            isShielded = true;
        }

        // Overrides the inherited IDamageable TakeDamage
        public int TakeDamage(int damage)
        {
            if (isShielded)
            {
                // shield absorbs all damage
                isShielded = false;
            }
            else
            {
                Health -= damage;
            }

            Console.WriteLine($"{Name}'s health is: {Health}");
            return Health;
        }
    }
}