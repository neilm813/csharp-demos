namespace OOPAbstractAndInterface
{
    public interface IDamageable
    {
        // Any classes that implement this interface MUST have health.
        int Health { get; set; } // get set needed b/c interface can't have fields (maybe changed in new versions of C#)

        string Name { get; set; }
        // Must have take damage FUNCTIONality
        int TakeDamage(int damage)
        {
            Health -= damage;
            return Health;
        }

        // You can provide a method signature only, and leave it up to the child classes to define how it works.
        // int TakeDamage(int amnt);
    }
}