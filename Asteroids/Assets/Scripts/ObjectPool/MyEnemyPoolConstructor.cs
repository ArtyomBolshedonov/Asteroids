using UnityEngine;
using System.Collections.Generic;


namespace Asteroids.ObjectPool
{
    internal sealed class MyEnemyPoolConstructor
    {
        private readonly Dictionary<string, MyEnemyPool> _enemyPool;

        public MyEnemyPoolConstructor(int capacity)
        {
            _enemyPool = new Dictionary<string, MyEnemyPool>(capacity);
        }

        public void Instantiate(Enemy enemy)
        {
            if(!_enemyPool.TryGetValue(enemy.gameObject.name, out MyEnemyPool enemyPool))
            {
                enemyPool = new MyEnemyPool(enemy);
                _enemyPool[enemy.gameObject.name] = enemyPool;
            }
            enemyPool.GetEnemy();
        }

        public void Destroy(Enemy enemy)
        {
            _enemyPool[enemy.gameObject.name].ReturnToPool(enemy);
        }
    }
}
