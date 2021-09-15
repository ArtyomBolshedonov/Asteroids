using UnityEngine;


namespace Asteroids.Decorator
{
    internal sealed class ModificationAim : ModificationPlayer
    {
        private readonly Aim _aim;

        public ModificationAim(Aim aim)
        {
            _aim = Object.Instantiate(aim);
        }

        protected override Player AddModification(Player player)
        {
            _aim.transform.position = player.Barrel.position + player.Barrel.up;
            _aim.transform.rotation = player.Barrel.rotation;
            return player;
        }

        protected override void HideModification(bool isActive)
        {
            _aim.gameObject.SetActive(isActive);
        }
    }
}
