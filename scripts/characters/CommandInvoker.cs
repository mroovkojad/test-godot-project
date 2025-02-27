
public partial class CommandInvoker : Node
{
    private ICommand _currentCommand;

    public void SetCommand(ICommand command)
    {
        _currentCommand = command;
    }

    public void ExecuteCommand(double delta)
    {
        if (_currentCommand != null)
        {
            _currentCommand.Execute(delta);
            _currentCommand = null;
        }
    }
}