namespace Asteroids.State
{
    internal sealed class HorizontalMovementState : MovementState
    {
        public HorizontalMovementState(Player player) : base(player)
        {
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Set(horizontal * Speed, 0.0f, 0.0f);
            base.Move(horizontal, vertical, deltaTime);
        }
    }
}
