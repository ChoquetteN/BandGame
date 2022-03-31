using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour, iControllableMenu
{
    // Get a list of actions the character can preform. 
    protected List<Moves> CharacterMoves;

    MusicalComponent musicalComponent;

    public int MenuIndex { get; private set; }

    [SerializeField]
    Image[] ArrowLocations;

    [SerializeField]
    Text[] ActionText;

    [SerializeField]
    Image UpArrow;

    [SerializeField]
    Image DownArrow;

    public virtual PlayerController.ActivityControlType controlForActivity { get { return PlayerController.ActivityControlType.MENU; } set { controlForActivity = value; } }

    void Start()
    {
        MenuIndex = 0;
    }

    void initMusicalComponent()
    {
        musicalComponent.addNote(0, "C2");
        musicalComponent.addNote(1, "D2");
        musicalComponent.addNote(2, "E2");
        musicalComponent.addNote(3, "F2");
        musicalComponent.addNote(4, "G2");
        musicalComponent.addNote(5, "A2");
        musicalComponent.addNote(6, "B2");
        musicalComponent.addNote(7, "C3");
    }

    public void setInstrument(string instrument)
    {
        if (musicalComponent == null) { musicalComponent = new MusicalComponent(); initMusicalComponent(); }
        musicalComponent.instrumentName = instrument;
    }

    public void Up()
    {
        if (MenuIndex - 1 >= 0)
        {
            MenuIndex--;
            musicalComponent.playSound(MenuIndex % musicalComponent.noteNameLength);
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
        if (MenuIndex + 1 < CharacterMoves.Count)
        {
            MenuIndex++;
            musicalComponent.playSound(MenuIndex % musicalComponent.noteNameLength);
            foreach (Image image in ArrowLocations)
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
        HideActivity();
        CharacterMoves[MenuIndex].Execute();
    }


    public void ShowActivity()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Left()
    {
        Up();
    }

    public virtual void Right()
    {
        Down();
    }

    public void HideActivity()
    {
        this.gameObject.SetActive(false);
    }

    public void UpKeyUp()
    {
        
    }

    public void DownKeyUp()
    {
       
    }

    public void LeftKeyUp()
    {
        
    }

    public void RightKeyUp()
    {
        
    }
}


