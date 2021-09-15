using UnityEngine;
using Asteroids.ChainOfResponsibility;
using Asteroids.Bridge;


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

        private void Awake()
        {
            var shipRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            var moveRigidBody = new AccelerationMove(shipRigidbody2D, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var shooting = new LaserShootingShip(_barrel, _laserSprite, _laserMass);
            var rocketAttack = new RocketAttack();
            Ship = new ShipChainOfResponsibility();
            var root = new ShipModifier(Ship);
            root.Add(new AddMoveModifier(Ship, moveRigidBody));
            root.Add(new AddRotationModifier(Ship, rotation));
            root.Add(new AddShootingModifier(Ship, shooting));
            root.Add(new AddRocketAttackModifier(Ship, rocketAttack));
            root.Handle();
        }
    }
}
