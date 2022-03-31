using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory
{
        
    public Queue<Character> LoadMoves(GameManager gm)
    {
        Queue<Character> queueToReturn = new Queue<Character>();
        List<Moves> ListOfMoves = new List<Moves>();
        ListOfMoves.Add(new AttackAction("Chorus", 15, gm.switchToMiniGame, MiniGame.MiniGameType.HAMMER));
        ListOfMoves.Add(new AttackAction("Chromatic Scale", 30, gm.switchToMiniGame, MiniGame.MiniGameType.WHIRLED));
        ListOfMoves.Add(new AttackAction("Improv", 20, gm.switchToMiniGame, MiniGame.MiniGameType.MEMORY));

        queueToReturn.Enqueue(new Character("Mike R Phone", "Voice",ListOfMoves, gm.PopulateMenu, gm.PlayerPositions[0].transform));

        ListOfMoves = new List<Moves>();

        ListOfMoves.Add(new AttackAction("The Rival band played: Cool music", 5 * (int)Random.Range(1,4), gm.displayAttack, MiniGame.MiniGameType.NONE));
        queueToReturn.Enqueue(new Character("Ronald badman", "Drum", ListOfMoves, gm.RivalPositions[0].transform));

        ListOfMoves = new List<Moves>();

        ListOfMoves.Add(new AttackAction("The Rival band played: Okay music", 7 * (int)Random.Range(1, 3), gm.displayAttack, MiniGame.MiniGameType.NONE));
        queueToReturn.Enqueue(new Character("DR SKELETONY", "Voice", ListOfMoves, gm.RivalPositions[2].transform));

        ListOfMoves = new List<Moves>();

        ListOfMoves.Add(new AttackAction("Gutair sound", 15, gm.switchToMiniGame, MiniGame.MiniGameType.HAMMER));
        ListOfMoves.Add(new AttackAction("power chord", 30,gm. switchToMiniGame, MiniGame.MiniGameType.MEMORY));
        ListOfMoves.Add(new AttackAction("sweep arpeggio", 20, gm.switchToMiniGame, MiniGame.MiniGameType.WHIRLED));
        queueToReturn.Enqueue(new Character("Dr. akula", "Guitar", ListOfMoves, gm.PopulateMenu, gm.PlayerPositions[1].transform));

        ListOfMoves = new List<Moves>();

        ListOfMoves.Add(new AttackAction("The Rival band played: rad music", 15, gm.displayAttack, MiniGame.MiniGameType.NONE));
        queueToReturn.Enqueue(new Character("Groovy person", "Guitar", ListOfMoves, gm.RivalPositions[1].transform));

        ListOfMoves = new List<Moves>();

        ListOfMoves.Add(new AttackAction("kick drum", 15, gm.switchToMiniGame, MiniGame.MiniGameType.HAMMER));
        ListOfMoves.Add(new AttackAction("keep the beat", 20, gm.switchToMiniGame, MiniGame.MiniGameType.MEMORY));
        ListOfMoves.Add(new AttackAction("drum solo", 30, gm.switchToMiniGame, MiniGame.MiniGameType.WHIRLED));
        queueToReturn.Enqueue(new Character("Drum machine", "Drum", ListOfMoves, gm.PopulateMenu, gm.PlayerPositions[2].transform));

        return queueToReturn;
    }
}
