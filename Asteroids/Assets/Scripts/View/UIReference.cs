using UnityEngine;
using Asteroids.Command;


namespace Asteroids
{
    internal sealed class UIReference
    {
        private Canvas _canvas;
        private HealthPanel _healthPanel;
        private TimePanel _timePanel;
        private ScorePanel _scorePanel;

        internal Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        internal HealthPanel HealthPanel
        {
            get
            {
                if (_healthPanel == null)
                {
                    var healthPanel = Resources.Load<HealthPanel>("HealthPanel");
                    _healthPanel = Object.Instantiate(healthPanel, Canvas.transform);
                }

                return _healthPanel;
            }
        }

        internal TimePanel TimePanel
        {
            get
            {
                if (_timePanel == null)
                {
                    var timePanel = Resources.Load<TimePanel>("TimePanel");
                    _timePanel = Object.Instantiate(timePanel, Canvas.transform);
                }

                return _timePanel;
            }
        }

        internal ScorePanel ScorePanel
        {
            get
            {
                if (_scorePanel == null)
                {
                    var scorePanel = Resources.Load<ScorePanel>("ScorePanel");
                    _scorePanel = Object.Instantiate(scorePanel, Canvas.transform);
                }

                return _scorePanel;
            }
        }
    }
}
