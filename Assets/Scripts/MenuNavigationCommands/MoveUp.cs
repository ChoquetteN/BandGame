
public class MoveUp : AssignableCommand
{
    public override void Execute()
    {
        _curControllableActivity.Up();
    }

    public override void KeyUp()
    {
        _curControllableActivity.UpKeyUp();
    }
}
