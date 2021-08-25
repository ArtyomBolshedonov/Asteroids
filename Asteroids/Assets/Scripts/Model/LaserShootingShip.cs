using UnityEngine;
using Asteroids.Builder;


namespace Asteroids
{
    internal sealed class LaserShootingShip : ShootingShip
    {
        private readonly Sprite _laserSprite;
        private readonly float _laserMass;

        public LaserShootingShip(Transform barrel, Sprite laserSprite, float laserMass) : base(barrel)
        {
            _laserSprite = laserSprite;
            _laserMass = laserMass;
        }

        public override void Shoot()
        {
            GameObject laser = new GameObjectBuilder().Visual.Name("Laser")
                .Sprite(_laserSprite)
                .Physics.Rigidbody2D(_laserMass)
                .BoxCollider2D();
            laser.transform.position = _barrel.position;
            laser.transform.rotation = _barrel.rotation;
            var laserRb = laser.GetComponent<Rigidbody2D>();
            laserRb.gravityScale = 0;
            laserRb.AddForce(_barrel.up);
        }
    }
}
