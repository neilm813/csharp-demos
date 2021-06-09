using System.Collections.Generic;

namespace MessageBoard
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        // You can't do anything to a list until it is instantiated.
        public List<Message> Messages { get; set; } = new List<Message>();

        /* 
        When creating new constructors, the default parameterless constructor
        is overridden and cannot be used unless you add it back.
        */
        public User() { }
        /* 
        Methods named the same as the class are constructors that construct
        the class when the "new" key word is used.

        Constructors automatically return a new instance.
        */
        public User(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            // this is implicitly happening
            LastName = lastName;
            Age = age;
        }
        public string FullName()
        {
            return FirstName + " " + LastName;
            // return this.FirstName + " " + this.LastName;
        }

        public Message SendMessage(Board board, string content)
        {
            if (content.Length < 3)
            {
                return null;
            }

            Message msg = new Message(content, this, board);
            board.Messages.Add(msg);

            Messages.Add(msg);
            return msg;
        }

        public int TotalWordCount()
        {
            int total = 0;

            foreach (Message msg in Messages)
            {
                total += msg.Content.Split(" ").Length;
            };

            return total;
        }

        /* 
        If you Console.WriteLine a class it runs the default ToString which
        only prints the name of the class. Here we can re-define what gets printed.
        */
        public override string ToString()
        {
            // $ lets you insert vars, @ sign preserves formatting like new lines.
            return $"Name: {FullName()} \nAge: {Age}";
        }
    }
}