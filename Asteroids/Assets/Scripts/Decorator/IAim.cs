using UnityEngine;


namespace Asteroids.Decorator
{
    internal interface IAim
    {
        Transform AimPosition { get; }
        GameObject AimInstance { get; }
    }
}
