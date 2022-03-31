using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour, iControllableMenu
{
    // Get the character who's turn it is.

    // Get a list of actions the character can preform. 
    List<Moves> CharacterMoves;


    // Select action

    int MenuIndex;

    [SerializeField]
    Image[] ArrowLocations;

    [SerializeField]
    Text[] ActionText;

    [SerializeField]
    Image UpArrow;

    [SerializeField]
    Image DownArrow;


    private void Start()
    {
        MenuIndex = 0;
        LabelMenuActions(MenuIndex);
    }

    public void Up()
    {
        if (MenuIndex - 1 >= 0)
        {
            SoundManager.Instance.AddCommand("Scroll");
            MenuIndex--;
            foreach (Image image in ArrowLocations)
            {
                image.enabled = false;
            }

            if (MenuIndex % ArrowLocations.Length == 2)
            {
                LabelMenuActions(MenuIndex - (ActionText.Length-1));
            }

            ArrowLocations[MenuIndex % ArrowLocations.Length].enabled = true;
        }
    }

    public void Down()
    {
        SoundManager.Instance.AddCommand("Scroll");
        if (MenuIndex + 1 < CharacterMoves.Count)
        {
            MenuIndex++;
            foreach(Image image in ArrowLocations)
            {
                image.enabled = false;
            }

            if(MenuIndex % ArrowLocations.Length == 0)
            {
                LabelMenuActions(MenuIndex);
            }

            ArrowLocations[MenuIndex % ArrowLocations.Length].enabled = true;
        }
    }

    public void PopulateMenu(List<Moves> nextCharactersMoves)
    {

        foreach (Image image in ArrowLocations)
        {
            image.enabled = false;
        }
        MenuIndex = 0;
        ArrowLocations[0].enabled = true;
        CharacterMoves = nextCharactersMoves;
        LabelMenuActions(MenuIndex);
    }

    public void LabelMenuActions(int TopOfPage)
    {
        for(int j = 0; j < ActionText.Length; j++)
        {
            ActionText[j].enabled = false;
        }
        for(int i = 0; i < ActionText.Length; i++ )
        {
            if (TopOfPage + i == CharacterMoves.Count) { break; }
            ActionText[i].enabled = true;
            ActionText[i].text = CharacterMoves[i + TopOfPage].MoveName;
        }

        DownArrow.enabled = TopOfPage + ActionText.Length < CharacterMoves.Count;

        UpArrow.enabled = TopOfPage != 0;

    }

    public void Select()
    {
        CharacterMoves[MenuIndex].Execute();
    }  
}


