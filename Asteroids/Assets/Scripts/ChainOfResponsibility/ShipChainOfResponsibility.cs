using Asteroids.Bridge;


namespace Asteroids.ChainOfResponsibility
{
    internal sealed class ShipChainOfResponsibility
    {
        public IMove MoveImplementation;
        public IRotation RotationImplementation;
        public IShoot ShootImplementation;
        public IAttack RocketAttackImplementation;
    }
}
