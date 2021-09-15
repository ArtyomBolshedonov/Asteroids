using UnityEngine;
using Asteroids.ChainOfResponsibility;


namespace Asteroids
{
    internal class MovementController : IExecute
    {
        private readonly ShipChainOfResponsibility _ship;
        private readonly Camera _camera;
        private readonly Transform _transform;
        private readonly KeyCode _accelerate;

        public MovementController(Player player, Camera camera)
        {
            _ship = player.Ship;
            _camera = camera;
            _transform = player.transform;
            _accelerate = KeyCode.LeftShift;
        }

        public void Execute(float deltaTime)
        {
            Move(deltaTime);
            Rotation();
            Acceleration();
            Deceleration();
        }

        private void Move(float deltaTime)
        {
            _ship.MoveImplementation.Move(Input.GetAxis(InputManager.HORIZONTAL), Input.GetAxis(InputManager.VERTICAL), deltaTime);
        }

        private void Rotation()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.RotationImplementation.Rotation(direction);
        }

        private void Acceleration()
        {
            if (Input.GetKeyDown(_accelerate)
                && _ship.MoveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        private void Deceleration()
        {
            if (Input.GetKeyUp(_accelerate)
                && _ship.MoveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
