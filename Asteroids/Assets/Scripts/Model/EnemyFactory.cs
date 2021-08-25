using UnityEngine;


namespace Asteroids
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private readonly Enemy _enemyObject;

        private readonly float _screenPositionX;
        private readonly float _screenPositionY;
        public EnemyFactory(Enemy enemy, Vector3 Borders)
        {
            _enemyObject = enemy;
            _screenPositionX = Borders.x;
            _screenPositionY = Borders.y;
        }
        public Enemy Create(Health hp)
        {
            var rand = Random.Range(-_screenPositionX, _screenPositionX);
            var startPosition = new Vector3(rand, _screenPositionY);
            var enemy = Object.Instantiate(_enemyObject, startPosition, Quaternion.identity);
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}
