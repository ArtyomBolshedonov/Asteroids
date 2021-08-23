using UnityEngine;


namespace Asteroids
{
    internal class MovementController : IExecute
    {
        private readonly Ship _ship;
        private Transform _transform;
        private Camera _camera;

        internal MovementController(Player player, Camera camera)
        {
            _ship = player.Ship;
            _transform = player.gameObject.transform;
            _camera = camera;
        }

        public void Execute()
        {
            Move();
            Rotation();
            Acceleration();
            Deceleration();
        }

        private void Move()
        {
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
        }

        private void Rotation()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.Rotation(direction);
        }

        private void Acceleration()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
        }

        private void Deceleration()
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
        }
    }
}
