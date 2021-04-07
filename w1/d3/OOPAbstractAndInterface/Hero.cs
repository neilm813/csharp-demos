using System;

namespace OOPAbstractAndInterface
{
    public class Hero : IDamageable
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Damage;
        public IDamageable HomeBase { get; set; }

        public Hero(string name)
        {
            Name = name;
            Health = 100;
            Damage = 10;
        }

        public int Attack(IDamageable target)
        {
            Console.WriteLine($"{Name} attacked {target.Name} for {Damage} damage.");
            return target.TakeDamage(Damage);
        }

        // The default behavior will be inherited from IDamageable
        // public int TakeDamage(int damage)
        // {
        //     Health -= damage;
        //     return Health;
        // }
    }
}