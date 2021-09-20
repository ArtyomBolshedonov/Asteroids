using System;

namespace Asteroids.Observer
{
    internal interface IHit
    {
        event Action<Enemy> OnHitChange;
        void Hit(Enemy enemy);
    }
}
