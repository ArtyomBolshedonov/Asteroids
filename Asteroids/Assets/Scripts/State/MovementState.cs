using UnityEngine;


namespace Asteroids.State
{
    internal abstract class MovementState : IMove
    {
        protected readonly Rigidbody2D _shipRigidbody2D;
        protected Vector3 _move;

        protected Speed SpeedMovement { get; }

        public float Speed { get; private set; }

        public MovementState(Player player)
        {
            _shipRigidbody2D = player.GetComponent<Rigidbody2D>();
            SpeedMovement = player.Speed;
        }

        public virtual void Move(float horizontal, float vertical, float deltaTime)
        {
            Speed = deltaTime * SpeedMovement.Current;
            _shipRigidbody2D.AddForce(_move);
        }
    }
}
