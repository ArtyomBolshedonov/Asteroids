using UnityEngine;
using Asteroids.ChainOfResponsibility;
using Asteroids.Bridge;
using Asteroids.State;


namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private float _laserMass;
        [SerializeField] private Sprite _laserSprite;
        [SerializeField] private Transform _barrel;

        public ShipChainOfResponsibility Ship { get; private set; }

        public Transform Barrel => _barrel;

        public MovementState MovementState { get; set; }

        public Speed Speed { get; private set; }

        public bool UnlockShooting { get; set; } = true;

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

        public long Scores { get; set; }

        public float Acceleration
        {
            get
            {
                return _acceleration;
            }
        }

        private void Awake()
        {
            Speed = new Speed(_speed,_speed);
            var rotation = new RotationShip(transform);
            var shooting = new LaserShootingShip(_barrel, _laserSprite, _laserMass);
            var rocketAttack = new RocketAttack();
            Ship = new ShipChainOfResponsibility();
            var root = new ShipModifier(Ship);
            root.Add(new AddMoveModifier(Ship, MovementState));
            root.Add(new AddRotationModifier(Ship, rotation));
            root.Add(new AddShootingModifier(Ship, shooting));
            root.Add(new AddRocketAttackModifier(Ship, rocketAttack));
            root.Handle();
        }
    }
}
