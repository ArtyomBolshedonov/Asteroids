using Asteroids.Bridge;


namespace Asteroids.ChainOfResponsibility
{
    internal sealed class AddRocketAttackModifier : ShipModifier
    {
        private readonly IAttack _rocketAttackImplementation;

        public AddRocketAttackModifier(ShipChainOfResponsibility ship, IAttack rocketAttackImplementation) : base(ship)
        {
            _rocketAttackImplementation = rocketAttackImplementation;
        }

        public override void Handle()
        {
            _ship.RocketAttackImplementation = _rocketAttackImplementation;
            base.Handle();
        }
    }
}
