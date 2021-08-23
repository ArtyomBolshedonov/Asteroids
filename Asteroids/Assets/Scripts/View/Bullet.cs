using UnityEngine;


namespace Asteroids
{
    internal sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private float _force;

        internal float Force
        {
            get
            {
                return _force;
            }
            private set
            {
                _force = value;
            }
        }
    }
}
