using UnityEngine;


namespace Asteroids
{
    internal sealed class BulletReference
    {
        private Bullet _bullet;

        internal Bullet Bullet
        {
            get
            {
                if (_bullet == null)
                {
                    _bullet = Resources.Load<Bullet>("Bullet");
                }
                return _bullet;
            }
        }
    }
}
