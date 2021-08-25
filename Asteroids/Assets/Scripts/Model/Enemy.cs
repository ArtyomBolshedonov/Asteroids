﻿using UnityEngine;
using Asteroids.ObjectPool;


namespace Asteroids
{
    internal abstract class Enemy : InteractiveObject, IMove
    {
        public static IEnemyFactory Factory;
        private Transform _rootPool;
        private Health _health;

        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }

        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rootPool = find == null ? null : find.transform;
                }

                return _rootPool;
            }
        }

        public static Enemy CreateEnemy(Enemy enemy, Health hp, Vector3 Borders)
        {
            var rand = UnityEngine.Random.Range(-Borders.x, Borders.x);
            var startPosition = new Vector3(-Borders.x, rand);
            var _enemy = Instantiate(enemy, startPosition, Quaternion.identity);
            _enemy.Health = hp;
            return _enemy;
        }

        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }

        public abstract void DependencyInjectHealth(Health hp);

        public float Speed { get; protected set; }
        public abstract void Move(float horizontal, float vertical, float deltaTime);
    }
}
