using UnityEngine;


namespace Asteroids
{
    internal sealed class FireController : IExecute
    {
        private readonly Ship _ship;

        public FireController(Player player)
        {
            _ship = player.Ship;
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetButtonDown(InputManager.FIRE1))
            {
                _ship.Shoot();
            }
        }
    }
}
