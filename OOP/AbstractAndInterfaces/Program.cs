using System;

namespace AbstractAndInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Bunker bunker1 = new Bunker("Bunker 1");
            Console.WriteLine($"Bunker 1 floors: {bunker1.Floors}");

            Hero hero1 = new Hero("Hero 1");
            // hero1.Strength += 10;
            Console.WriteLine(hero1.Strength);

            Hero hero2 = new Hero("Hero 2");

            hero1.Attack(bunker1);
            hero1.Attack(hero2);
        }
    }
}
