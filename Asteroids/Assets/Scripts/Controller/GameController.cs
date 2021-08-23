using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        private GameStarter _gameStarter;
        private List<IExecute> _listExecuteObject;
        private MovementController _movementController;
        private FireController _fireController;
        private GameLogicController _gameLogicController;

        private void Start()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
            _listExecuteObject = new List<IExecute>();
            _movementController = new MovementController(_gameStarter.Player, _gameStarter.Camera);
            _listExecuteObject.Add(_movementController);
            _fireController = new FireController(_gameStarter.Player);
            _listExecuteObject.Add(_fireController);
            _gameLogicController = new GameLogicController(_gameStarter.GetEnemies(), _gameStarter.Player);
            _listExecuteObject.Add(_gameLogicController);
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
