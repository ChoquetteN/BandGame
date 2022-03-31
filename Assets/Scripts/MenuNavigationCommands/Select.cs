using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : AssignableCommand
{
    public override void Execute()
    {
        _curControllableActivity.Select();
    }

    public override void KeyUp()
    {
        
    }
}
