namespace Asteroids.Decorator
{
    internal abstract class ModificationPlayer
    {
        private Player _player;
        protected abstract Player AddModification(Player player);
        protected abstract void HideModification(bool isActive);

        public void ApplyModification(Player player)
        {
            _player = AddModification(player);
        }

        public void RemoveModification(bool isActive)
        {
            HideModification(isActive);
        }
    }
}
