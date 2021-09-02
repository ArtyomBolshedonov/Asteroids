using UnityEngine;
using System.Collections.Generic;
using Asteroids.Facade;


namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private float _screenBorderX = 30;
        [SerializeField] private float _screenBorderY = 20;
        [SerializeField] private Sprite _backgroundImage;

        private ReferenceCreator _referenceCreator;
        private List<Enemy> _enemies;
        private MapCreator _map;

        public Player Player { get; private set; }
        public Camera Camera { get; private set; }
        public Aim Aim { get; private set; }

        private void Start()
        {
            _referenceCreator = new ReferenceCreator();
            Player = _referenceCreator.GetPlayerobjects().Player;
            Camera = _referenceCreator.GetPlayerobjects().MainCamera;
            Aim = _referenceCreator.GetPlayerobjects().Aim;

            _map = new MapCreator(_screenBorderX, _screenBorderY, _backgroundImage);

            _enemies = new List<Enemy>();

            _enemies.Add(Enemy.CreateEnemy(_referenceCreator.GetEnemyObjects().Asteroid,
                new Health(50.0f, 50.0f), _map.MapBorders));
            _enemies.Add(Enemy.CreateEnemy(_referenceCreator.GetEnemyObjects().Meteor,
                new Health(20.0f, 20.0f), _map.MapBorders));

            IEnemyFactory cometFactory = new EnemyFactory(_referenceCreator.GetEnemyObjects().Comet, _map.MapBorders);
            _enemies.Add(cometFactory.Create(new Health(70.0f, 70.0f)));

            IEnemyFactory enemyShipFactory = new EnemyFactory(_referenceCreator.GetEnemyObjects().EnemyShip, _map.MapBorders);
            _enemies.Add(enemyShipFactory.Create(new Health(100.0f, 100.0f)));
        }

        public List<Enemy> GetEnemies()
        {
            return _enemies;
        }
    }
}
