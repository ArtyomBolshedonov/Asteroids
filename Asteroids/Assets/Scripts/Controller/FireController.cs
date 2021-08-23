using UnityEngine;


namespace Asteroids
{
    internal sealed class FireController : IExecute
    {
        private Ship _ship;

        internal FireController(Player player)
        {
            _ship = player.Ship;
        }

        public void Execute()
        {
            Shooting();
        }

        private void Shooting()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _ship.Shoot();
            }
        }
    }
}
