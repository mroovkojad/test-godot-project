public abstract partial class BaseCharacter : CharacterBody2D {
    protected float Speed = 300.0f;
    protected float JumpVelocity = -400.0f;
    protected Vector2 _velocity = Vector2.Zero;

    public void Move(Vector2 direction)
    {
        _velocity.X = direction.X * Speed;
    }

    public void Jump()
    {
        if (IsOnFloor())
        {
            _velocity.Y = JumpVelocity;
        }
    }

    public void Stop()
    {
        _velocity.X = Mathf.MoveToward(_velocity.X, 0, Speed);
    }

}