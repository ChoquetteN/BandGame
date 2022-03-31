using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{

    public Queue<Character> LoadMoves(GameManager gm)
    {
        Queue<Character> queueToReturn = new Queue<Character>();
        List<Moves> Temp = new List<Moves>();
        Temp.Add(new AttackAction("Sing", 10, gm.DrawNextCharacter));
        Temp.Add(new AttackAction("start dancing", 15, gm.DrawNextCharacter));
        Temp.Add(new AttackAction("La La", 20, gm.DrawNextCharacter));
        queueToReturn.Enqueue(new Character("Mike R Phone", Temp));

        Temp = new List<Moves>();

        Temp.Add(new AttackAction("Gutair sound", 10, gm.DrawNextCharacter));
        Temp.Add(new AttackAction("power chord", 15, gm.DrawNextCharacter));
        Temp.Add(new AttackAction("sweep arpegio", 20, gm.DrawNextCharacter));
        queueToReturn.Enqueue(new Character("Dr. akula", Temp));

        Temp = new List<Moves>();

        Temp.Add(new AttackAction("Snazzy snairs", 10, gm.DrawNextCharacter));
        Temp.Add(new AttackAction("kick drum", 15, gm.DrawNextCharacter));
        Temp.Add(new AttackAction("Crash symbol", 20, gm.DrawNextCharacter));
        queueToReturn.Enqueue(new Character("Drum machine", Temp));

        return queueToReturn;
    }
}
