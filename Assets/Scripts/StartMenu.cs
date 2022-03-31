using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : CombatMenu
{
    public override PlayerController.ActivityControlType controlForActivity { get { return PlayerController.ActivityControlType.START_MENU; } set { controlForActivity = value; } }

    public StartGameCommand startGame;
    // Have a list of game objects
    [SerializeField]
    List<GameObject> imagesToHideBeforeStart;

    [SerializeField]
    Text TitleText;

    [SerializeField]
    Text DescriptionText;

    private void Start()
    {
        setInstrument("Guitar");
        CharacterMoves = new List<Moves>();
        CharacterMoves.Add(startGame);
        CharacterMoves.Add(new QuitGame());
        PopulateMenu(CharacterMoves);
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        gameObject.SetActive(true);
        hideAllElements();
    }

    void hideAllElements()
    {
        foreach (GameObject i in imagesToHideBeforeStart)
        {
            i.gameObject.SetActive(false);
        }
    }

    void HideStartMenu()
    {
        gameObject.SetActive(false);
    }

    public void StartGame()
    {
        foreach(GameObject i in imagesToHideBeforeStart)
        {
            i.gameObject.SetActive(true);
        }
    }

    public void SetTitleText(string titleText)
    {
        TitleText.text = titleText;
    }

    public void SetDescription(string descriptionText)
    {
        DescriptionText.text = descriptionText;
    }

    public override void Left()
    {
        Up();
    }

    public override void Right()
    {
        Down();
    }
}
