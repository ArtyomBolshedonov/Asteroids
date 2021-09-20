using UnityEngine;


namespace Asteroids.Command
{
    internal abstract class BaseUI : MonoBehaviour
    {
        public abstract void Active();
        public abstract void Hide();
    }
}
