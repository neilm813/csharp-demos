namespace AbstractAndInterfaces
{
    public interface IDamageable
    {
        // Any class that implements this interface MUST have health.
        int Health { get; set; }

        // So we can't display messages about who was damaged.
        string Name { get; set; }

        /* 
        Must have take damage FUNCTIONality.
        Method signature only, up to the child classes to define how it works.

        If we want to, we can provide a default implementation of this method's logic.
        */
        // int TakeDamage(int amnt);

        int TakeDamage(int amnt)
        {
            Health -= amnt;
            return Health;
        }
    }
}