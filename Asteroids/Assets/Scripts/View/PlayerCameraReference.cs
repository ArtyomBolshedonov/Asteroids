using UnityEngine;


namespace Asteroids
{
    internal sealed class PlayerCameraReference
    {
        private Player _player;
        private Camera _mainCamera;
        private Aim _aim;

        internal Player Player
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<Player>("Player");
                    _player = Object.Instantiate(gameObject);
                }

                return _player;
            }
        }

        internal Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        internal Aim Aim
        {
            get
            {
                if (_aim == null)
                {
                    _aim = Resources.Load<Aim>("Aim");
                }

                return _aim;
            }
        }
    }
}
