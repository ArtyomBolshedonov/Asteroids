namespace Asteroids.ChainOfResponsibility
{
    internal class ShipModifier
    {
        protected ShipChainOfResponsibility _ship;
        protected ShipModifier Next;

        public ShipModifier(ShipChainOfResponsibility ship)
        {
            _ship = ship;
        }

        public void Add(ShipModifier shipModifier)
        {
            if (Next != null)
            {
                Next.Add(shipModifier);
            }
            else
            {
                Next = shipModifier;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}
