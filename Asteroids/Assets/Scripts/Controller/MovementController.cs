using UnityEngine;
using Asteroids.ChainOfResponsibility;
using Asteroids.State;
using System.Collections.Generic;


namespace Asteroids
{
    internal class MovementController : IExecute
    {
        private readonly ShipChainOfResponsibility _ship;
        private readonly Camera _camera;
        private readonly Transform _transform;
        private readonly KeyCode _accelerate;
        private readonly List<MovementState> _movementStates;

        public MovementController(Player player, Camera camera)
        {
            _ship = player.Ship;
            _camera = camera;
            _transform = player.transform;
            _accelerate = KeyCode.LeftShift;
            _movementStates = new List<MovementState>
            {
                new HorizontalMovementState(player),
                new VerticalMovementState(player),
                new AccelerationMovementState(player)
            };
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
            foreach (var item in _movementStates)
            {
                item.Move(Input.GetAxis(InputManager.HORIZONTAL), Input.GetAxis(InputManager.VERTICAL), deltaTime);
            }
        }

        private void Rotation()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.RotationImplementation.Rotation(direction);
        }

        private void Acceleration()
        {
            foreach (var item in _movementStates)
            {
                if (Input.GetKeyDown(_accelerate)
                && item is AccelerationMovementState accelerationMovementState)
                {
                    accelerationMovementState.AddAcceleration();
                }
            }
        }

        private void Deceleration()
        {
            foreach (var item in _movementStates)
            {
                if (Input.GetKeyUp(_accelerate)
                && item is AccelerationMovementState accelerationMovementState)
                {
                    accelerationMovementState.RemoveAcceleration();
                }
            }
        }
    }
}
