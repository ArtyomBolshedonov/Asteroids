namespace Asteroids.Proxy
{
    internal sealed class UnlockShooting
    {
        public bool IsUnlock { get; set; }

        public UnlockShooting(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }
    }
}
