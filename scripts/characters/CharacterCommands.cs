
public class MoveLeftCommand : ICommand
{
    private readonly IMover _mover;

    public MoveLeftCommand(IMover mover)
    {
        _mover = mover;
    }

    public void Execute(double delta)
    {
        _mover.MoveLeft(delta);
    }

}


public class MoveRightCommand : ICommand
{
    private readonly IMover _mover;

    public MoveRightCommand(IMover mover)
    {
        _mover = mover;
    }

    public void Execute(double delta)
    {
        _mover.MoveRight(delta);
    }

}

public class JumpCommand : ICommand
{
    private readonly IMover _mover;
    private bool _wasGrounded;

    public JumpCommand(IMover mover)
    {
        _mover = mover;
        _wasGrounded = mover.IsGrounded();
    }

    public void Execute(double delta)
    {
        if (_wasGrounded)
        {
            _mover.Jump();
        }
    }

}