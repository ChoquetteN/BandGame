using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApperanceManager : MonoBehaviour
{

    [System.Serializable]
    public struct NamedImages
    {
        public string KeyName;
        public Sprite keySprite;
    }
    public static ApperanceManager instance { get; private set; }

     Dictionary<string, Sprite> MiniGameArt;

    Dictionary<string, NamedImages> KeyboardArt;

    public Sprite[] miniGameArt = new Sprite[4];

    public NamedImages[] keyBoardArtSprite = new NamedImages[4];

    public void Awake()
    {
        instance = this;
        initSpriteArtByCatagory(miniGameArt, out MiniGameArt);
        initSpriteArtByCatagory(keyBoardArtSprite, out KeyboardArt);
    }

    void initSpriteArtByCatagory(NamedImages[] spriteArr, out Dictionary<string, NamedImages> artHolder)
    {
        artHolder = new Dictionary<string, NamedImages>();
        for (int i = 0; i < spriteArr.Length; i++)
        {
            artHolder.Add(spriteArr[i].KeyName, spriteArr[i]);
        }
    }

    void initSpriteArtByCatagory(Sprite[] spriteArr, out Dictionary<string, Sprite> artHolder)
    {
        artHolder = new Dictionary<string, Sprite>();
        for (int i = 0; i < spriteArr.Length; i++)
        {
            artHolder.Add(spriteArr[i].name, spriteArr[i]);
        }
    }

    public Sprite FindMinigameArtByName(string spriteToLookFor)
    {
        Sprite test;
        if (MiniGameArt.TryGetValue(spriteToLookFor, out test))
        {
            return test;
        }

        if(KeyboardArt.ContainsKey(spriteToLookFor))
        {
            return KeyboardArt[spriteToLookFor].keySprite;
        }
        string[] parts = spriteToLookFor.Split('_');
        Debug.Log($"Could not find {spriteToLookFor}");
        return MiniGameArt[parts[0]];
    }
}

