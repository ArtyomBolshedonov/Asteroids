using UnityEngine;


namespace Asteroids.Proxy
{
    internal sealed class ShootingShipProxy : IShoot
    {
        private readonly IShoot _shoot;
        private readonly UnlockShooting _unlockShooting;

        public ShootingShipProxy(IShoot shoot, UnlockShooting unlockShooting)
        {
            _shoot = shoot;
            _unlockShooting = unlockShooting;
        }

        public void Shoot()
        {
            if (_unlockShooting.IsUnlock)
            {
                _shoot.Shoot();
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }
    }
}
