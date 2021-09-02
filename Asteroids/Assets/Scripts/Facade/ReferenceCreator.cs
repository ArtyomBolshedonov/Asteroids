namespace Asteroids.Facade
{
    internal sealed class ReferenceCreator
    {
        private readonly PlayerCameraReference _playerCameraReference;
        private readonly EnemyReference _enemyReference;
        private readonly BulletReference _bulletReference;

        public ReferenceCreator()
        {
            _playerCameraReference = new PlayerCameraReference();
            _enemyReference = new EnemyReference();
            _bulletReference = new BulletReference();
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
    }
}
