using UnityEngine;


namespace Asteroids.Bridge
{
    internal sealed class RocketAttack : IAttack
    {
        public void Attack(Transform transform)
        {
            var rocket = Object.Instantiate(new BulletReference().Rocket,
                transform.position, transform.rotation);
            rocket.BulletFly(transform.up * rocket.Speed);
        }
    }
}
