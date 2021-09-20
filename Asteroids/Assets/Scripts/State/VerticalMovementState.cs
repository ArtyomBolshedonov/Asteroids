namespace Asteroids.State
{
    internal sealed class VerticalMovementState : MovementState
    {
        public VerticalMovementState(Player player) : base(player)
        {
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Set(0.0f, vertical * Speed, 0.0f);
            base.Move(horizontal, vertical, deltaTime);
        }
    }
}
