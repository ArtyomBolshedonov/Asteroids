namespace Asteroids.State
{
    internal sealed class AccelerationMovementState : MovementState
    {
        public readonly float _acceleration;

        public AccelerationMovementState(Player player) : base(player)
        {
            _acceleration = player.Acceleration;
        }

        public void AddAcceleration()
        {
            SpeedMovement.ChangeCurrentSpeed(SpeedMovement.Current + _acceleration);
        }

        public void RemoveAcceleration()
        {
            SpeedMovement.ChangeCurrentSpeed(SpeedMovement.Current - _acceleration);
        }
    }
}
