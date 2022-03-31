using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCommand : Moves
{
    public override string MoveName
    {
        get { return "Let's Rock"; } protected set {; }
    }

    Action startGame;

    public StartGameCommand(string MoveName, Action startGame)
    {
        this.MoveName = MoveName;
        this.startGame = startGame;
    }


    public override void Execute()
    {
        startGame.Invoke();
    }
}
