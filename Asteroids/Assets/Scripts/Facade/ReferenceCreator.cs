namespace Asteroids.Facade
{
    internal sealed class ReferenceCreator
    {
        private readonly PlayerCameraReference _playerCameraReference;
        private readonly EnemyReference _enemyReference;
        private readonly BulletReference _bulletReference;
        private readonly UIReference _uIReference;

        public ReferenceCreator()
        {
            _playerCameraReference = new PlayerCameraReference();
            _enemyReference = new EnemyReference();
            _bulletReference = new BulletReference();
            _uIReference = new UIReference();
        }

        public PlayerCameraReference GetPlayerobjects()
        {
            return _playerCameraReference;
        }

        public EnemyReference GetEnemyObjects()
        {
            return _enemyReference;
        }

        public BulletReference GetBulletObjects()
        {
            return _bulletReference;
        }

        public UIReference GetUIObjects()
        {
            return _uIReference;
        }
    }
}
