using System.Collections.Generic;
using UnityEngine;
using Asteroids.Command;
using Asteroids.Interpreter;


namespace Asteroids
{
    internal sealed class UIController : IExecute
    {
        private readonly UIReference _uIReference;
        private readonly HealthPanel _healthPanel;
        private readonly TimePanel _timePanel;
        private readonly ScorePanel _scorePanel;
        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
        private readonly Player _player;
        private readonly ScoreFormatter _scoreFormatter;
        private BaseUI _currentWindow;

        public UIController(UIReference uIReference, Player player)
        {
            _uIReference = uIReference;
            _healthPanel = _uIReference.HealthPanel;
            _timePanel = _uIReference.TimePanel;
            _scorePanel = _uIReference.ScorePanel;
            _player = player;
            _scoreFormatter = new ScoreFormatter();
            _healthPanel.Hide();
            _timePanel.Hide();
            _scorePanel.Hide();
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentChoice(StateUI.HealthPanel);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentChoice(StateUI.TimePanel);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CurrentChoice(StateUI.ScorePanel);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_stateUi.Count > 0)
                {
                    CurrentChoice(_stateUi.Pop(), false);
                }
            }
        }

        private void CurrentChoice(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Hide();
            }

            switch (stateUI)
            {
                case StateUI.HealthPanel:
                    _healthPanel.Health = _player.Health;
                    _currentWindow = _healthPanel;
                    break;

                case StateUI.TimePanel:
                    _currentWindow = _timePanel;
                    break;

                case StateUI.ScorePanel:
                    _scorePanel.Scores = _scoreFormatter.Interpret(_player.Scores.ToString());
                    _currentWindow = _scorePanel;
                    break;

                default:
                    break;
            }

            _currentWindow.Active();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }
    }
}
