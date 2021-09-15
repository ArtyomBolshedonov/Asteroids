using UnityEngine;
using System.Collections.Generic;
using Asteroids.Decorator;


namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        private GameStarter _gameStarter;
        private List<IExecute> _listExecuteObject;
        private MovementController _movementController;
        private FireController _fireController;
        private GameMechanicTester _gameLogicController;
        private UIController _uIController;

        private void Start()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
            _listExecuteObject = new List<IExecute>();
            _movementController = new MovementController(_gameStarter.Player, _gameStarter.Camera);
            _listExecuteObject.Add(_movementController);
            ModificationAim modificationPlayer = new ModificationAim(_gameStarter.Aim);
            _fireController = new FireController(_gameStarter.Player, modificationPlayer);
            _listExecuteObject.Add(_fireController);
            _gameLogicController = new GameMechanicTester(_gameStarter.GetEnemies(), _gameStarter.Player);
            _listExecuteObject.Add(_gameLogicController);
            _uIController = new UIController(_gameStarter.GetUI(), _gameStarter.Player);
            _listExecuteObject.Add(_uIController);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            foreach (var item in _listExecuteObject)
            {
                item.Execute(deltaTime);
            }
        }
    }
}
