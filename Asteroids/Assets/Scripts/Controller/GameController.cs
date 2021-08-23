using UnityEngine;


namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        private PlayerCameraReference _playerCameraReference;
        private Player _player;
        private Camera _camera;
        private ListExecuteObject _listExecuteObject;
        private MovementController _inputController;
        private FireController _fireController;

        private void Start()
        {
            _playerCameraReference = new PlayerCameraReference();
            _player = _playerCameraReference.Player;
            _camera = _playerCameraReference.MainCamera;
            _listExecuteObject = new ListExecuteObject();
            _inputController = new MovementController(_player, _camera);
            _listExecuteObject.AddExecuteObject(_inputController);
            _fireController = new FireController(_player);
            _listExecuteObject.AddExecuteObject(_fireController);
        }

        private void Update()
        {
            for (var i = 0; i < _listExecuteObject.Length; i++)
            {
                var listExecuteObject = _listExecuteObject[i];

                if (listExecuteObject == null)
                {
                    continue;
                }
                listExecuteObject.Execute();
            }
        }
    }
}
