﻿using UnityEngine;
using System;
using Asteroids.ObjectPool;
using Asteroids.Bridge;
using Asteroids.Observer;


namespace Asteroids
{
    internal abstract class Enemy : InteractiveObject, IMove, IHit
    {
        public static IEnemyFactory Factory;
        private Transform _rootPool;
        private Health _health;
        private IAnotherMove _anotherMove;

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

        protected Transform RootPool
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

        public event Action<Enemy> OnHitChange = delegate (Enemy e) { };

        private void Awake()
        {
            _anotherMove = new AroundMove();
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

        public void ReturnToPool()
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

        public void AroundMove()
        {
            _anotherMove.AnotherMove(transform);
        }

        protected override void Interaction()
        {
            IsInteractable = false;
            base.Interaction();
        }

        protected override void SelfInteraction()
        {
            IsInteractable = false;
            Player.Scores += _scores;
        }

        public void Hit(Enemy enemy)
        {
            OnHitChange.Invoke(enemy);
        }
    }
}
