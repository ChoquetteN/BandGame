using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memory : MiniGame
{
    public override MiniGameType miniGameType { get { return MiniGameType.MEMORY; } }

    string[] artLookUpNames = { "A_Key_Up", "S_Key_Up", "D_Key_Up", "W_Key_Up" };

    LetterKeys[] correctKeys = new LetterKeys[4];

    [SerializeField]
    Image[] OnScreenKeyPrompts = new Image[(int)LetterKeys.COUNT];

    int CurKeyIndex;

    int inputIndex;

    const float timeBetweenEachNumber = 0.5f;

    bool areControlsLocked;

    void Start()
    {
        musicalComponent.addNote((int)LetterKeys.LEFT,  "C2");
        musicalComponent.addNote((int)LetterKeys.DOWN, "F2");
        musicalComponent.addNote((int)LetterKeys.RIGHT,  "G2");
        musicalComponent.addNote((int)LetterKeys.UP,  "C3");
        menuStartPosition = new Vector3(-Camera.main.pixelWidth - MiniGameBackground.rectTransform.rect.size.x, MiniGameBackground.transform.position.y, MiniGameBackground.transform.position.z);
        menuEndPosition = new Vector3(MiniGameBackground.transform.position.x, MiniGameBackground.transform.position.y, MiniGameBackground.transform.position.z);
        menuTargetPosition = menuEndPosition;
        MiniGameBackground.transform.position = menuStartPosition;

    }

    public override void ShowActivity()
    {
        hideKeys();
        CurKeyIndex = 0;
        inputIndex = 0;
        chooseCorrectLetters();
        menuTargetPosition = menuEndPosition;
        base.ShowActivity();
        TimerManager.Instance.createTimer(timeBetweenEachNumber, revealNextLetter);
        areControlsLocked = true;
    }

    void chooseCorrectLetters()
    {
        for(int i = 0; i < correctKeys.Length; i++)
        {
            correctKeys[i] = (LetterKeys)Random.Range(0, (int)LetterKeys.COUNT);
        }
    }

   void revealNextLetter()
    {
        if (CurKeyIndex >= 4)
        {
            TimerManager.Instance.createTimer(timeBetweenEachNumber, hideKeys);
        }
        else
        {
            OnScreenKeyPrompts[CurKeyIndex].sprite = ApperanceManager.instance.FindMinigameArtByName(artLookUpNames[(int)correctKeys[CurKeyIndex]]);
            musicalComponent.playSound((int)correctKeys[CurKeyIndex]);
            CurKeyIndex++;
            TimerManager.Instance.createTimer(timeBetweenEachNumber, revealNextLetter);
        }
    }

     void hideKeys()
    {
        for(int i = 0; i < OnScreenKeyPrompts.Length; i++)
        {
            OnScreenKeyPrompts[i].sprite = ApperanceManager.instance.FindMinigameArtByName("?_Key_Up");
        }
        areControlsLocked = false;
    }

    void checkIfCorrectKey(LetterKeys pressedKeyId)
    {
        if (!areControlsLocked)
        {
            if (correctKeys[inputIndex] == pressedKeyId)
            {
                sendToast(MiniGameToasts[inputIndex], inputIndex);
                musicalComponent.playSound((int)correctKeys[inputIndex]);
                OnScreenKeyPrompts[inputIndex].sprite = ApperanceManager.instance.FindMinigameArtByName(artLookUpNames[(int)correctKeys[inputIndex]]);
                inputIndex++;
                if (inputIndex == correctKeys.Length)
                    CalculateDamage(true);
            }
            else
                CalculateDamage(false);
        }
    }

    void CalculateDamage(bool fullDamage)
    {
        EndAttack(FullDamageValue * (inputIndex / OnScreenKeyPrompts.Length));
    }

    void EndAttack(float damage)
    {
        DamageValue = Mathf.CeilToInt(damage);
        TimerManager.Instance.createTimer(0.3f, EndActivityTimerCountDown);
        areControlsLocked = true;
    }

    public override void Down()
    {
        checkIfCorrectKey(LetterKeys.DOWN);
    }

    public override void Left()
    {
        checkIfCorrectKey(LetterKeys.LEFT);
    }

    public override void Right()
    {
        checkIfCorrectKey(LetterKeys.RIGHT);
    }

    public override void Up()
    {
        checkIfCorrectKey(LetterKeys.UP);
    }

}
