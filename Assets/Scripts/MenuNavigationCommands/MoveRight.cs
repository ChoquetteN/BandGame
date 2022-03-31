using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : AssignableCommand
{
    public override void Execute()
    {
        _curControllableActivity.Right();
    }

    public override void KeyUp()
    {
        _curControllableActivity.RightKeyUp();
    }
}
