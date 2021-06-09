/* 
Use OOP to create message boards and users that can send messages on the
message board.
*/

using System;

namespace MessageBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataType varName = "some value";
            int x = 5;

            /* 
            Instantiate a user with the default parameter-less constructor.
            Manually fill in the property values.
            */
            User user1 = new User()
            {
                FirstName = "Neil",
                LastName = "Mos",
                Age = 32
            };

            User user2 = new User("Sean", "Caylor", 37);

            // Console.WriteLine(user1);
            // Console.WriteLine(user2);

            Board board1 = new Board("Stonks", "We like the stonk.");
            Board board2 = new Board("Cute Doggos.", "Puppers and woofers.");

            user2.SendMessage(board1, "I plead the 5th.");
            user2.SendMessage(board1, "What is your Reasonable Articulable Suspicion that I am engaged in stonk manipulation, officer?");

            user2.SendMessage(board2, "I'm partial to Akbashs. It's Turkish for 'White Head'.");
            user1.SendMessage(board2, "Anyone ever heard of a Lundehund?");
            user1.SendMessage(board2, "Tibetan Mastiffs are pretty dope.");

            Console.WriteLine(user1.TotalWordCount());
            Console.WriteLine(user2.TotalWordCount());
            Console.WriteLine(board1.TopUser());
            Console.WriteLine(board2.TopUser());

            // foreach (Message msg in user2.Messages)
            // {
            //     Console.WriteLine(msg);
            // }

            // for (int i = 0; i < user2.Messages.Count; i++)
            // {
            //     Console.WriteLine(user2.Messages[i]);
            // }
        }
    }
}
