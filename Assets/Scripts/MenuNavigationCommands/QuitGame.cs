using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : Moves
{
    public override string MoveName { get => "Quit"; protected set {; } }

    public override void Execute()
    {
        Debug.Log("app quit");
        Application.Quit();
    }
}
