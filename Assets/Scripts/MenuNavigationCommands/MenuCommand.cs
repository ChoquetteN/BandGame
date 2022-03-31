public abstract class AssignableCommand : iCommand, iControllableObserver
{
    
    protected iActivity _curControllableActivity { get; private set; }

    public abstract void Execute();

    public abstract void KeyUp();


    public void transition()
    {

    }

    public void UpdateObserver(iActivity curActivity)
    {
        _curControllableActivity = curActivity;
    }
}
