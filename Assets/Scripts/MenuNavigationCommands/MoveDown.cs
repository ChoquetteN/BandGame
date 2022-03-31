public class MoveDown : AssignableCommand
{
    public override void Execute()
    {
        _curControllableActivity.Down();
    }

    public override void KeyUp()
    {
        _curControllableActivity.DownKeyUp();
    }
}
