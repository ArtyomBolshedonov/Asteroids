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
        private float _shootTime;
        private float _rocketTime;

        public GameMechanicTester(List<Enemy> enemies, Player player)
        {
            _enemies = enemies;
            _player = player;
            _shootTime = _gunReloadTime;
            _rocketTime = _gunReloadTime * 3;
        }

        public void Execute(float deltaTime)
        {
            _shootTime -= deltaTime;
            _rocketTime -= deltaTime;
            foreach (var item in _enemies)
            {
                if (item != null)
                {
                    _direction = _player.gameObject.transform.position - item.gameObject.transform.position;
                    item.Move(_direction.x, _direction.y, deltaTime);
                    RotateAround(item);
                    if (item is EnemyShip enemyShip)
                    {
                        EnemyAimShoot(enemyShip);
                    }
                }
            }
        }

        private void EnemyAimShoot(EnemyShip enemyShip)
        {
            enemyShip.Rotation(_direction);
            if (_shootTime <= 0 && enemyShip.isActiveAndEnabled)
            {
                enemyShip.Shoot();
                _shootTime = _gunReloadTime;
            }
            if(_rocketTime <=0 && enemyShip.isActiveAndEnabled)
            {
                enemyShip.RocketAttack();
                _rocketTime = _gunReloadTime*3;
            }
        }

        private void RotateAround(Enemy enemy)
        {
            if(enemy is Meteor || enemy is Asteroid)
            {
                enemy.AroundMove();
            }
        }
    }
}
