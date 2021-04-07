namespace OOPAbstractAndInterface
{
    public class Tower : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }

        public Tower(string name, int health = 100, int floors = 2)
        {
            Name = name;
            Health = health;

            // Overwriting the default floors from the abstract building class.
            Floors = floors;
        }

        // Default TakeDamage method inherited from IDamageable
    }
}