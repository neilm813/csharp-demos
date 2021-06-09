using System;

namespace MessageBoard
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User Author { get; set; }
        public Board Board { get; set; }

        public Message(string content, User author, Board board)
        {
            Content = content;
            Author = author;
            Board = board;
        }

        public override string ToString()
        {
            return $"Content: {Content} \nAuthor: {Author.FullName()}";
        }
    }
}