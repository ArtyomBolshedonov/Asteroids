using UnityEngine;


namespace Asteroids
{
    internal sealed class Meteor : Enemy
    {
        [SerializeField] private float _speed;
        private Vector3 _movedirection;

        public override void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            Speed = deltaTime * _speed;
            _movedirection.Set(horizontal * Speed, vertical * Speed, 0.0f);
            GetComponent<Rigidbody2D>().AddForce(_movedirection*Speed);
        }
    }
}
