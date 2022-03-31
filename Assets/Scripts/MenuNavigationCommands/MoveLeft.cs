public class MoveLeft : AssignableCommand
{

    public override void Execute()
    {
        _curControllableActivity.Left();
    }

    public override void KeyUp()
    {
        _curControllableActivity.LeftKeyUp();
    }
}
