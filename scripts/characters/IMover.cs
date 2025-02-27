public interface IMover
{
    void MoveLeft(double delta);
    void MoveRight(double delta);
    void Jump();
    void StopHorizontalMovement();
    bool IsGrounded();
}