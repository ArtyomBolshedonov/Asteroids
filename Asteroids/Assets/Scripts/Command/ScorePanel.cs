using UnityEngine;
using UnityEngine.UI;


namespace Asteroids.Command
{
    internal sealed class ScorePanel : BaseUI
    {
        [SerializeField] private Text _text;

        public string Scores { get; set; }

        public override void Active()
        {
            _text.text = Scores;
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
