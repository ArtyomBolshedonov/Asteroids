namespace Asteroids.ChainOfResponsibility
{
    internal sealed class AddMoveModifier : ShipModifier
    {
        private readonly IMove _moveImplementation;

        public AddMoveModifier(ShipChainOfResponsibility ship, IMove moveImplementation) : base (ship)
        {
            _moveImplementation = moveImplementation;
        }

        public override void Handle()
        {
            _ship.MoveImplementation = _moveImplementation;
            base.Handle();
        }
    }
}
