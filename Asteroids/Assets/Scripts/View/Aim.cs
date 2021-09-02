using UnityEngine;
using Asteroids.Decorator;


namespace Asteroids
{
    internal sealed class Aim : MonoBehaviour, IAim
    {
        public Transform AimPosition => gameObject.transform;

        public GameObject AimInstance => gameObject;
    }
}
