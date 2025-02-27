
public partial class InputHandler : Node
{
    private CommandInvoker _commandInvoker;
    private IMover _controlledEntity;

    public InputHandler(IMover controlledEntity)
    {
        _controlledEntity = controlledEntity;
        _commandInvoker = new CommandInvoker();
        AddChild(_commandInvoker);
    }

    public void ProcessInput(double delta)
    {
        // Check for movement input
        if (Input.IsActionPressed("ui_left"))
        {
            _commandInvoker.SetCommand(new MoveLeftCommand(_controlledEntity));
        }
        else if (Input.IsActionPressed("ui_right"))
        {
            _commandInvoker.SetCommand(new MoveRightCommand(_controlledEntity));
        }
        else
        {
            _controlledEntity.StopHorizontalMovement();
        }

        // Check for jump input
        if (Input.IsActionJustPressed("ui_up") && _controlledEntity.IsGrounded())
        {
            _commandInvoker.SetCommand(new JumpCommand(_controlledEntity));
        }

        // Execute the current command
        _commandInvoker.ExecuteCommand(delta);
    }

}