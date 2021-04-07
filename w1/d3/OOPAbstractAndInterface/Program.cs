using System;
using System.Collections.Generic;

namespace OOPAbstractAndInterface
{
    class Program
    {
        static void Main(string[] args)
        {

            Hero hero1 = new Hero("Shrek");
            Bunker shreksBunker = new Bunker("Shrek's Bunker");
            hero1.HomeBase = shreksBunker;

            Hero hero2 = new Hero("PussNBoots");

            Bunker bunker1 = new Bunker("Farquad's Bunker");

            Tower tower1 = new Tower("Dragon Tower");

            hero1.Attack(hero2);
            Console.WriteLine(hero1.Attack(bunker1));
            Console.WriteLine(hero1.Attack(bunker1));
            Console.WriteLine(hero1.Attack(tower1));
        }
    }
}
