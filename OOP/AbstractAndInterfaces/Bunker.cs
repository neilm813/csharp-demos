namespace AbstractAndInterfaces
{
    public class Bunker : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }
        private bool isShielded = true;

        public Bunker(string name)
        {
            Name = name;
            Health = 300;

            // Will be 1 from the abstract class or 3 with un-commented.
            // Floors = 3;
        }

        public int TakeDamage(int amnt)
        {
            if (isShielded)
            {
                // Take no damage, but shield is broken.
                isShielded = false;
            }
            else
            {
                Health -= amnt;
            }

            return Health;
        }
    }
}