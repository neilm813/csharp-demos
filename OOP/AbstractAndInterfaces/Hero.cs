using System;

namespace AbstractAndInterfaces
{
    public class Hero : IDamageable
    {
        public int Health { get; set; }
        public string Name { get; set; }
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                if (value < 0)
                {
                    strength = 0;
                }
                else
                {
                    strength = value;
                }
            }
        }

        public Hero(string name)
        {
            Name = name;
            Health = 100;
            strength = 10;
        }

        public void Attack(IDamageable target)
        {
            target.TakeDamage(strength);
            Console.WriteLine($"{Name} attacked {target.Name} for {strength} damage.");
        }

        // If this is commented out, we inherit the default TakeDamage method from the IDamageable interface.
        // public int TakeDamage(int amnt)
        // {
        //     Health -= amnt;
        //     return Health;
        // }
    }
}