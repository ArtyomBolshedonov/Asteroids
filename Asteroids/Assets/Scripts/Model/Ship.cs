using UnityEngine;
using Asteroids.Bridge;


namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IShoot
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IShoot _shootImplementation;
        private readonly IAttack _rocketAttack;

        public float Speed => _moveImplementation.Speed;

        public Ship(IMove moveImplementation, IRotation rotationImplementation, IShoot shootImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _shootImplementation = shootImplementation;
            _rocketAttack = new RocketAttack();
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void Shoot()
        {
            _shootImplementation.Shoot();
        }

        public void RocketAttack(Transform barrel)
        {
            _rocketAttack.Attack(barrel);
        }
    }
}
