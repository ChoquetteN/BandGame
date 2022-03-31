public abstract class Moves : iCommand
{
    public abstract string MoveName { get; protected set; }

    public abstract void Execute();
}