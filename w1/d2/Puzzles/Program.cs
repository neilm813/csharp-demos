using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {

            // int[] randNums = RandomArray();

            // Console.WriteLine($"TossCoin() returned {TossCoin()}");

            // double headsRatio = TossMultipleCoins(5);
            // Console.WriteLine(headsRatio);

            List<string> longNames = Names();
            Console.WriteLine(String.Join(", ", longNames));
        }

        /* 
        [x] Create a function called RandomArray() that returns an integer array
        [x] Place 10 random integer values between 5-25 into the array
        [x] Print the min and max values of the array
        [x] Print the sum of all the values
        */
        static int[] RandomArray()
        {
            Random r = new Random();
            int[] randNums = new int[10];
            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < 10; i++)
            {
                int rand = r.Next(5, 26);

                if (rand < min)
                {
                    min = rand;
                }

                if (rand > max)
                {
                    max = rand;
                }

                randNums[i] = rand;
            }

            Console.WriteLine($"Min: {min}, Max: {max}");
            return randNums;
        }

        /* 
        [x] Create a function called TossCoin() that returns a string
        [x] Have the function print "Tossing a Coin!"
        [x] Randomize a coin toss with a result signaling either side of the coin 
        [x] Have the function print either "Heads" or "Tails"
        [x] Finally, return the result
        */
        static string TossCoin()
        {
            Random r = new Random();
            int rand = r.Next(0, 2);
            string result = "Heads";

            Console.WriteLine("Tossing a Coin!");

            if (rand == 0)
            {
                result = "Tails";
            }

            Console.WriteLine(result);
            return result;
        }

        /* 
        [x] Create another function called TossMultipleCoins(int num) that returns a Double
        [x] Have the function call the tossCoin function multiple times based on num value
        [x] Have the function return a Double that reflects the ratio of head toss to total toss
        */
        static double TossMultipleCoins(int num)
        {
            double headsCount = 0;

            for (int i = 0; i < num; i++)
            {
                string result = TossCoin();

                if (result == "Heads")
                {
                    headsCount++;
                }
            }

            return headsCount / num;
        }

        /* 
        [x] Build a function Names that returns a list of strings.  In this function:
        [x] Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        [x] Shuffle the list and print the values in the new order
        [x] Return a list that only includes names longer than 5 characters
        */
        static List<string> Names()
        {
            List<string> names = new List<string>
            {
                "Todd", "Tiffany", "Charlie", "Geneva", "Sydney"
            };

            List<string> longerNames = new List<string>();

            for (int i = 0; i < names.Count; i++)
            {
                Random r = new Random();
                int rand = r.Next(0, names.Count);

                string temp = names[i];
                names[i] = names[rand];
                names[rand] = temp;
            }

            foreach (string currentName in names)
            {
                if (currentName.Length > 5)
                {
                    longerNames.Add(currentName);
                }
            }

            Console.WriteLine(String.Join(",", names));
            return longerNames;
            // this can replace the foreach loop
            // return names.Where(name => name.Length > 5).ToList();
        }
    }
}
