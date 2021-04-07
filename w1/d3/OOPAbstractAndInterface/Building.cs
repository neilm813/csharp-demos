namespace OOPAbstractAndInterface
{
    public abstract class Building
    {
        // Not every building has health b/c every building isn't damageable

        // abstract prop means it must be implemented or overriden on the child class
        public abstract string Name { get; set; }

        // virtual means it CAN be overriden but doesn't need to be.
        public virtual int Floors { get; set; }

        // Abstract classes are not instantiated directly, but this constructure will be executed when any class that inherits this Building is constructed.
        public Building()
        {
            // shared default value.
            Floors = 1;
        }
    }
}