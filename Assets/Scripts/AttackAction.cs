using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : Moves
{
    public override string MoveName { get; protected set; }

    public delegate void NextAction(AttackAction Attack);
    NextAction next;

    public int damageValue { get; private set; }

    // Used to find what mini game to use, may also be based on the mini game's real name. 
    public MiniGame.MiniGameType _MiniGameType { get; }

    public AttackAction(string name, int _damageValue, NextAction nextAction, MiniGame.MiniGameType miniGameType)
    {
        MoveName = name;
        damageValue = _damageValue;
        next = nextAction;
        _MiniGameType = miniGameType;
    }

    public override void Execute()
    {
        next.Invoke(this);
    }
}
