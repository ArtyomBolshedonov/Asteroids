using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class GameMechanicTester : IExecute
    {
        private readonly List<Enemy> _enemies;
        private readonly Player _player;
        private Vector3 _direction;
        private readonly float _gunReloadTime = 2.0f;
        private float currentTime;

        public GameMechanicTester(List<Enemy> enemies, Player player)
        {
            _enemies = enemies;
            _player = player;
            currentTime = _gunReloadTime;
        }

        public void Execute(float deltaTime)
        {
            currentTime -= deltaTime;
            foreach (var item in _enemies)
            {
                _direction = _player.gameObject.transform.position - item.gameObject.transform.position;
                item.Move(_direction.x, _direction.y, deltaTime);
                if (item is EnemyShip enemyShip)
                {
                    EnemyAimShoot(enemyShip);
                }
            }
        }

        private void EnemyAimShoot(EnemyShip enemyShip)
        {
            enemyShip.Rotation(_direction);
            if (currentTime <= 0 && enemyShip.isActiveAndEnabled)
            {
                enemyShip.Shoot();
                currentTime = _gunReloadTime;
            }
        }
    }
}
