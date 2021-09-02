using UnityEngine;


namespace Asteroids
{
    internal sealed class BulletReference
    {
        private Bullet _bullet;
        private Rocket _rocket;
        
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

        internal Rocket Rocket
        {
            get
            {
                if (_rocket == null)
                {
                    _rocket = Resources.Load<Rocket>("Rocket");
                }
                return _rocket;
            }
        }
    }
}
