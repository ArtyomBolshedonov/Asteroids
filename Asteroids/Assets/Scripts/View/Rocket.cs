using UnityEngine;


namespace Asteroids
{
    internal sealed class Rocket : Bullet
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;

        protected override void Interaction()
        {
            Player.UnlockShooting = false;
            base.Interaction();
        }
    }
}
