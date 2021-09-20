namespace Asteroids
{
    internal sealed class Speed
    {
        public float Max { get; }
        public float Current { get; private set; }

        public Speed(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentSpeed(float speed)
        {
            Current = speed;
        }
    }
}
