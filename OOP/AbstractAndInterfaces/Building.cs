namespace AbstractAndInterfaces
{
    public abstract class Building
    {
        // Not every building has health b/c every building isn't damageable

        // Abstract prop means it must be implemented / overriden by the child class that inherits this class.
        public abstract string Name { get; set; }

        // Virtual means it CAN be overriden but doesn't need to be, it will be inherited if not overriden.
        public virtual int Floors { get; set; }

        // This constructor gets called when the child class is constructed.
        public Building()
        {
            // Shared default to all children that inherit this class but the child's constructor may override this default.
            Floors = 1;
        }
    }
}