using UnityEngine;
using Asteroids.ObjectPool;


namespace Asteroids
{
    internal class ShootingShip : IShoot
    {
        protected Transform _barrel;
        private BulletPool _bulletPool;

        public ShootingShip(Transform barrel)
        {
            _barrel = barrel;
        }

        public virtual void Shoot()
        {
            if (_bulletPool == null)
            {
                _bulletPool = new BulletPool(5);
            }
            var bullet = _bulletPool.GetBullet("Bullet");
            bullet.ActiveBullet(_barrel.position, _barrel.rotation);
            bullet.BulletFly(_barrel.up);
        }
    }
}
