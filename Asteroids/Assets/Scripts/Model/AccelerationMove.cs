using UnityEngine;


namespace Asteroids
{
    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;

        internal AccelerationMove(Rigidbody2D shipRigidbody2D, float speed, float acceleration) : base(shipRigidbody2D, speed)
        {
            _acceleration = acceleration;
        }

        internal void AddAcceleration()
        {
            Speed += _acceleration;
        }

        internal void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
