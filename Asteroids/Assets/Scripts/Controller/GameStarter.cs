using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private float _screenBorderX = 30;
        [SerializeField] private float _screenBorderY = 20;

        private PlayerCameraReference _playerCameraReference;
        private EnemyReference _enemyReference;
        private List<Enemy> _enemies;

        public Player Player { get; private set; }
        public Camera Camera { get; private set; }

        private void Start()
        {
            _playerCameraReference = new PlayerCameraReference();
            Player = _playerCameraReference.Player;
            Camera = _playerCameraReference.MainCamera;

            var gameBorders = new Vector3(_screenBorderX, _screenBorderY);

            _enemyReference = new EnemyReference();
            _enemies = new List<Enemy>();

            _enemies.Add(Enemy.CreateEnemy(_enemyReference.Asteroid,
                new Health(50.0f, 50.0f), gameBorders));
            _enemies.Add(Enemy.CreateEnemy(_enemyReference.Meteor,
                new Health(20.0f, 20.0f), gameBorders));

            IEnemyFactory cometFactory = new EnemyFactory(_enemyReference.Comet, gameBorders);
            _enemies.Add(cometFactory.Create(new Health(70.0f, 70.0f)));

            IEnemyFactory enemyShipFactory = new EnemyFactory(_enemyReference.EnemyShip, gameBorders);
            _enemies.Add(enemyShipFactory.Create(new Health(100.0f, 100.0f)));
        }

        public List<Enemy> GetEnemies()
        {
            return _enemies;
        }
    }
}
