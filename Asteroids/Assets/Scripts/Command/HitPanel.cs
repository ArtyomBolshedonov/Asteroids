using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Asteroids.Command
{
    internal sealed class HitPanel : BaseUI
    {
        [SerializeField] private Text _text;

        public string HitInfo { get; set; }

        public override void Active()
        {
            _text.text += HitInfo + "\n";
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
