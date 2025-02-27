
public abstract partial class AbstractCharacter : CharacterBody2D, IMover
{
    [Export]
    public float MoveSpeed { get; set; } = 300.0f;

    [Export]
    public float JumpVelocity { get; set; } = -400.0f;

    protected AnimatedSprite2D _animatedSprite;
    protected CommandInvoker _commandInvoker;

    // Get the gravity from the project settings
    public float Gravity => (float)ProjectSettings.GetSetting("physics/2d/default_gravity");

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _commandInvoker = new CommandInvoker();
        AddChild(_commandInvoker);

        // Allow derived classes to perform additional initialization
        OnReady();
    }

    // Virtual method for derived classes to override for custom initialization
    protected virtual void OnReady() { }

    public override void _PhysicsProcess(double delta)
    {
        // Add gravity
        if (!IsOnFloor())
        {
            Vector2 velocity = Velocity;
            velocity.Y += Gravity * (float)delta;
            Velocity = velocity;
        }

        // Let derived classes handle their specific behavior
        UpdateBehavior(delta);

        // Execute the current command
        _commandInvoker.ExecuteCommand(delta);

        // Apply movement
        MoveAndSlide();
    }

    // Abstract method that derived classes must implement to define their behavior
    protected abstract void UpdateBehavior(double delta);

    // IMover interface implementation
    public void MoveLeft(double delta)
    {
        Vector2 velocity = Velocity;
        velocity.X = -MoveSpeed;
        Velocity = velocity;

        _animatedSprite.FlipH = true;
        _animatedSprite.Play("run");
    }

    public void MoveRight(double delta)
    {
        Vector2 velocity = Velocity;
        velocity.X = MoveSpeed;
        Velocity = velocity;

        _animatedSprite.FlipH = false;
        _animatedSprite.Play("run");
    }

    public void Jump()
    {
        Vector2 velocity = Velocity;
        velocity.Y = JumpVelocity;
        Velocity = velocity;

        _animatedSprite.Play("jump");
    }

    public void StopHorizontalMovement()
    {
        Vector2 velocity = Velocity;
        velocity.X = 0;
        Velocity = velocity;

        if (IsOnFloor())
            _animatedSprite.Play("idle");
    }

    public bool IsGrounded()
    {
        return IsOnFloor();
    }
}
