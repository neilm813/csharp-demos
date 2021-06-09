using System;
using System.Collections.Generic;

namespace MessageBoard
{
    public class Board
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Message> Messages { get; set; } = new List<Message>();

        public Board(string name, string topic)
        {
            Name = name;
            Topic = topic;
        }

        public User TopUser()
        {
            Dictionary<User, int> messageCounts = new Dictionary<User, int>();
            int max = 0;
            User topUser = null;

            foreach (Message msg in Messages)
            {
                if (messageCounts.ContainsKey(msg.Author))
                {
                    messageCounts[msg.Author]++;
                }
                else
                {
                    messageCounts[msg.Author] = 1;
                }

                int currCount = messageCounts[msg.Author];

                if (currCount > max)
                {
                    max = currCount;
                    topUser = msg.Author;
                }
            }
            return topUser;
        }
    }
}