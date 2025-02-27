
public partial class EnemySlime : AbstractCharacter
{
    private float _directionChangeTimer = 0;
    private float _currentDirection = -1; // -1 left, 1 right

    protected override void OnReady()
    {
        // Enemy-specific initialization
        MoveSpeed = 150.0f; // Slower than player
        JumpVelocity = -350.0f; // Lower jump
    }

    protected override void UpdateBehavior(double delta)
    {
        // Simple AI behavior
        _directionChangeTimer += (float)delta;

        // Change direction every 3 seconds
        if (_directionChangeTimer > 3.0f)
        {
            _currentDirection *= -1;
            _directionChangeTimer = 0;
        }

        // Execute movement command based on current direction
        if (_currentDirection < 0)
        {
            _commandInvoker.SetCommand(new MoveLeftCommand(this));
        }
        else
        {
            _commandInvoker.SetCommand(new MoveRightCommand(this));
        }

        // Random jumps
        if (GD.Randf() < 0.01 && IsOnFloor()) // 1% chance to jump per frame
        {
            _commandInvoker.SetCommand(new JumpCommand(this));
        }
    }
}