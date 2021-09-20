using UnityEngine;
using UnityEngine.UI;


namespace Asteroids.Command
{
    internal sealed class TimePanel : BaseUI
    {
        [SerializeField] private Text _text;

        public override void Active()
        {
            _text.text = nameof(TimePanel);
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
