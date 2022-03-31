using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : AssignableCommand
{
    public override void Execute()
    {
        Application.Quit();
    }

    public override void KeyUp()
    {

    }
}
