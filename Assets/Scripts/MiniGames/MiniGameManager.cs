using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    MiniGame[] miniGames; 

    Dictionary<MiniGame.MiniGameType, MiniGame> MiniGameLookup;

    void Start()
    {
        initMiniGameByName(miniGames , out MiniGameLookup);
    }

    void initMiniGameByName(MiniGame[] minigameArray, out Dictionary<MiniGame.MiniGameType, MiniGame> _miniGame )
    {
        _miniGame = new Dictionary<MiniGame.MiniGameType, MiniGame>();

        for (int i = 0; i < minigameArray.Length; i++)
        {
            _miniGame.Add(minigameArray[i].miniGameType, minigameArray[i]);
        }
    }

    public MiniGame FindMiniGameByName(MiniGame.MiniGameType miniGameName)
    {
        return MiniGameLookup[miniGameName];
    }
}
