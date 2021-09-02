using UnityEngine;


namespace Asteroids.Bridge
{
    internal sealed class AroundMove : IAnotherMove
    {
        private readonly float _angle = 1.0f;
        public void AnotherMove(Transform transform)
        {
            transform.RotateAround(transform.position, transform.forward, _angle);
        }
    }
}
