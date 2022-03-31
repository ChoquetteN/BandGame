using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTurnManager : MonoBehaviour
{
    Queue<Character> characterOrder;

    private void Start()
    {
        characterOrder = new Queue<Character>();
    }

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
