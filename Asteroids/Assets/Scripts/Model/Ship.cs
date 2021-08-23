using UnityEngine;


namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IShoot
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IShoot _shootImplementation;

        public float Speed => _moveImplementation.Speed;

        internal Ship(IMove moveImplementation, IRotation rotationImplementation, IShoot shootImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _shootImplementation = shootImplementation;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        internal void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        internal void RemoveAcceleration()
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
    }
}
