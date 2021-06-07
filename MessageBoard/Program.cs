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



            Message msg1 = new Message("I plead the 5th.", user2);
            Message msg2 = new Message("What is your Reasonable Articulable Suspicion, officer?", user2);

            user2.Messages.Add(msg1);
            user2.Messages.Add(msg2);

            Console.WriteLine(user1);
            Console.WriteLine(user2);

            foreach (Message msg in user2.Messages)
            {
                Console.WriteLine(msg);
            }

            for (int i = 0; i < user2.Messages.Count; i++)
            {
                Console.WriteLine(user2.Messages[i]);
            }
        }
    }
}
