namespace Asteroids.ChainOfResponsibility
{
    internal sealed class AddRotationModifier : ShipModifier
    {
        private readonly IRotation _rotationImplementation;

        public AddRotationModifier(ShipChainOfResponsibility ship, IRotation rotationImplementation) : base(ship)
        {
            _rotationImplementation = rotationImplementation;
        }

        public override void Handle()
        {
            _ship.RotationImplementation = _rotationImplementation;
            base.Handle();
        }
    }
}
