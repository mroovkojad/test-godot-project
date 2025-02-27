public partial class Player : AbstractCharacter
{
    protected override void UpdateBehavior(double delta)
    {
        // Process input and create commands
        HandleInput(delta);
    }

    private void HandleInput(double delta)
    {
        if (Input.IsActionPressed("ui_left"))
        {
            _commandInvoker.SetCommand(new MoveLeftCommand(this));
        }
        else if (Input.IsActionPressed("ui_right"))
        {
            _commandInvoker.SetCommand(new MoveRightCommand(this));
        }
        else
        {
            StopHorizontalMovement();
        }

        if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
        {
            _commandInvoker.SetCommand(new JumpCommand(this));
        }
    }
}