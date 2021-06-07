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

        public override string ToString()
        {
            // $ lets you insert vars, @ sign preserves formatting like new lines.
            return $"Name: {FullName()} \nAge: {Age}";
        }
    }
}