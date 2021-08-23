using UnityEngine;


namespace Asteroids
{
    internal sealed class Bullet : InteractiveObject
    {
        [SerializeField] private float _force;
        [SerializeField] private float _damage;

        public void BulletFly(Vector3 direction)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * _force);
        }

        protected override void Interaction()
        {
            Player.Health -= _damage;
        }
    }
}
