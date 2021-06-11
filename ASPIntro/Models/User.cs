namespace ASPIntro.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

    }
}