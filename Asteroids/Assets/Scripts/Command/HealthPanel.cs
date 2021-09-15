using UnityEngine;
using UnityEngine.UI;


namespace Asteroids.Command
{
    internal sealed class HealthPanel : BaseUI
    {
        [SerializeField] private Text _text;

        public float Health { get; set; }

        public override void Active()
        {
            _text.text = Health.ToString();
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
