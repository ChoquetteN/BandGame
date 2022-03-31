using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character :iHaveMoves
{
    [SerializeField]
    Sprite image;

    public Transform coasterTransform { get; private set; }

    public delegate void OnTurnStart(List<Moves> characterMoves);
    public OnTurnStart onTurnStart;

    public string Name { get; private set; }

    public string Instrument { get; private set; }

    public List<Moves> CharacterMoves { get; set; }

    public Character(string _name, string instrument, List<Moves> _characterMoves , Transform _CharacterCoasterLocation) 
    {
        Name = _name;
        Instrument = instrument;
        CharacterMoves = _characterMoves;
        this.onTurnStart = chooseMove;
        coasterTransform = _CharacterCoasterLocation;
    }

    public Character(string _name, string instrument , List<Moves> _characterMoves, OnTurnStart onTurnStart, Transform _CharacterCoasterLocation)
    {
        Name = _name;
        Instrument = instrument;
        CharacterMoves = _characterMoves;
        this.onTurnStart = onTurnStart;
        coasterTransform = _CharacterCoasterLocation;
    }

    void chooseMove(List<Moves> _characterMoves)
    {
        _characterMoves[0].Execute();
    }
}
