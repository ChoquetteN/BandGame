using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, iHaveMoves
{
    [SerializeField]
    Sprite image; 

    public Character(string _name, List<Moves> _characterMoves)
    {
        Name = _name;
        CharacterMoves = _characterMoves;
    }

    public string Name { get; set; }

    public List<Moves> CharacterMoves { get ; set; }
}
