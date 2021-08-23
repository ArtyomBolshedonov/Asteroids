﻿using UnityEngine;


namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Transform _barrel;
        public Ship Ship { get; private set; }

        public float Health
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }

        private void Awake()
        {
            var shipRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            var moveRigidBody = new AccelerationMove(shipRigidbody2D, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var shooting = new ShootingShip(_barrel);
            Ship = new Ship(moveRigidBody, rotation, shooting);
        }
    }
}
