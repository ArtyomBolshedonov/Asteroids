using UnityEngine;
using Asteroids.ChainOfResponsibility;


namespace Asteroids.Proxy
{
    internal sealed class ShootingShipProxy : IShoot
    {
        private readonly ShipChainOfResponsibility _ship;
        private readonly UnlockShooting _unlockShooting;

        public ShootingShipProxy(ShipChainOfResponsibility ship, UnlockShooting unlockShooting)
        {
            _ship = ship;
            _unlockShooting = unlockShooting;
        }

        public void Shoot()
        {
            if (_unlockShooting.IsUnlock)
            {
                _ship.ShootImplementation.Shoot();
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }
    }
}
