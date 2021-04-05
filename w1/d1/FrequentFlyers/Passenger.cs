namespace FrequentFlyers
{
    public class Passenger
    {
        // Auto-implemented Property
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor is a method with same name as class name. It auto returns the new instance.
        public Passenger(string firstName, string lastName)
        {
            // equivalent to this.FirstName = firstName
            // the class property is being set with the value from the parameter.
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}