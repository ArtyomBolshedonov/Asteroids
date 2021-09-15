using UnityEngine;
using Asteroids.Decorator;
using Asteroids.Proxy;


namespace Asteroids
{
    internal sealed class FireController : IExecute
    {
        private readonly Player _player;
        private readonly ModificationAim _modificationPlayer;
        private readonly ShootingShipProxy _shootingShipProxy;
        private readonly UnlockShooting _unlockShooting;

        public FireController(Player player, ModificationAim modificationPlayer)
        {
            _player = player;
            _modificationPlayer = modificationPlayer;
            _unlockShooting = new UnlockShooting(_player.UnlockShooting);
            var ship = player.Ship;
            _shootingShipProxy = new ShootingShipProxy(ship, _unlockShooting);
        }

        public void Execute(float deltaTime)
        {
            AimAndShoot(_player);
        }

        private void AimAndShoot(Player player)
        {
            if (Input.GetButtonDown(InputManager.FIRE1) && !Input.GetButton(InputManager.FIRE2))
            {
                _shootingShipProxy.Shoot();
            }
            else if (Input.GetButton(InputManager.FIRE2))
            {
                _modificationPlayer.ApplyModification(player);
                if (Input.GetButtonDown(InputManager.FIRE1))
                {
                    player.Ship.RocketAttackImplementation.Attack(player.Barrel);
                }
            }
            _modificationPlayer.RemoveModification(Input.GetButton(InputManager.FIRE2));
            _unlockShooting.IsUnlock = _player.UnlockShooting;
        }
    }
}
