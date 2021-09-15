using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.ObjectPool
{
    internal sealed class MyEnemyPool
    {
        private readonly Stack<Enemy> _enemies = new Stack<Enemy>();
        private readonly Enemy _enemy;
        private readonly Transform _rootPool;

        public MyEnemyPool(Enemy enemy)
        {
            _enemy = enemy;
            _rootPool = new GameObject(enemy.gameObject.name).transform;
        }

        public Enemy GetEnemy()
        {
            Enemy enemy;
            if(_enemies.Count == 0)
            {
                enemy = Object.Instantiate(_enemy);
                enemy.name = _enemy.name;
            }
            else
            {
                enemy = _enemies.Pop();
            }
            enemy.gameObject.SetActive(true);
            enemy.transform.SetParent(null);
            return enemy;
        }

        public void ReturnToPool(Enemy enemy)
        {
            _enemies.Push(enemy);
            enemy.transform.SetParent(_rootPool);
            enemy.gameObject.SetActive(false);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }

    }
}
