namespace AbstractAndInterfaces
{
    // Non damageable Building
    public class Tower : Building
    {
        public int Health { get; set; }
        public override string Name { get; set; }

        public Tower(string name, int floors = 3)
        {
            Name = name;
            Floors = floors;
        }
    }
}