using UnityEngine;
using Asteroids.ObjectPool;


namespace Asteroids
{
    internal sealed class ShootingShip : IShoot
    {
        private readonly Transform _barrel;
        private readonly BulletPool _bulletPool;

        public ShootingShip(Transform barrel)
        {
            _bulletPool = new BulletPool(5);
            _barrel = barrel;
        }

        public void Shoot()
        {
            var bullet = _bulletPool.GetBullet("Bullet");
            bullet.transform.position = _barrel.position;
            bullet.transform.rotation = _barrel.rotation;
            bullet.gameObject.SetActive(true);
            bullet.BulletFly(_barrel.up);
        }
    }
}
