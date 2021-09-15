namespace Asteroids.ChainOfResponsibility
{
    internal sealed class AddShootingModifier : ShipModifier
    {
        private readonly IShoot _shootImplementation;

        public AddShootingModifier(ShipChainOfResponsibility ship, IShoot shootImplementation) : base(ship)
        {
            _shootImplementation = shootImplementation;
        }

        public override void Handle()
        {
            _ship.ShootImplementation = _shootImplementation;
            base.Handle();
        }
    }
}
