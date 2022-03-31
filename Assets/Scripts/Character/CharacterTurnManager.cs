using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTurnManager : MonoBehaviour
{
    Queue<Character> characterOrder;

    public void LoadCharacterList(Queue<Character> characters)
    {
        characterOrder = characters;
    }

    public Character LoadNextCharacter()
    {
        Character ToReturn = characterOrder.Dequeue();
        characterOrder.Enqueue(ToReturn);
        return ToReturn;
    }
}
