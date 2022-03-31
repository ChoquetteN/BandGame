using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Whirled : MiniGame
{
    public override MiniGameType miniGameType { get { return MiniGame.MiniGameType.WHIRLED; } }

    LetterKeys targetKeyId = 0;

    [SerializeField]
    Image[] OnScreenKeyPrompts = new Image[(int)LetterKeys.COUNT];

    [SerializeField]
    Image BarFullArt;

    [SerializeField]
    Slider DonenessBarContent;

    int laps = 0;

    const float MAX_LAPS = 5;

    bool areControlsLocked;

    void Start()
    {
        musicalComponent.addNote((int)LetterKeys.LEFT,  "C2");
        musicalComponent.addNote((int)LetterKeys.DOWN,  "F2");
        musicalComponent.addNote((int)LetterKeys.RIGHT,  "G2");
        musicalComponent.addNote((int)LetterKeys.UP, "C3");
        menuStartPosition = new Vector3(-Camera.main.pixelWidth - MiniGameBackground.rectTransform.rect.size.x, MiniGameBackground.transform.position.y, MiniGameBackground.transform.position.z);
        menuEndPosition = new Vector3(MiniGameBackground.transform.position.x, MiniGameBackground.transform.position.y, MiniGameBackground.transform.position.z);
        OnScreenKeyPrompts[(int)LetterKeys.LEFT].sprite = ApperanceManager.instance.FindMinigameArtByName("A_Key_Up");
        OnScreenKeyPrompts[(int)LetterKeys.DOWN].sprite = ApperanceManager.instance.FindMinigameArtByName("S_Key_Up");
        OnScreenKeyPrompts[(int)LetterKeys.RIGHT].sprite = ApperanceManager.instance.FindMinigameArtByName("D_Key_Up");
        OnScreenKeyPrompts[(int)LetterKeys.UP].sprite = ApperanceManager.instance.FindMinigameArtByName("W_Key_Up");
        menuTargetPosition = menuEndPosition;
        MiniGameBackground.transform.position = menuStartPosition;
        
    }

    public override void ShowActivity()
    {
        laps = 0;
        targetKeyId = LetterKeys.LEFT;
        DonenessBarContent.value = 0;
        DonenessBarContent.maxValue = (MAX_LAPS + 1) * (int)LetterKeys.COUNT;
        BarFullArt.sprite = ApperanceManager.instance.FindMinigameArtByName("StarDot");
        foreach (Image i in OnScreenKeyPrompts) { i.color = Color.grey; }
        HilightWhatKeyToPress();
        menuTargetPosition = menuEndPosition;
        base.ShowActivity();
        TimerManager.Instance.createTimer(3, CalculateDamage);
        areControlsLocked = false;
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

    void checkIfCorrectKey(LetterKeys pressedKeyId)
    {
        if (!areControlsLocked)
        {
            if (targetKeyId == pressedKeyId)
            {
                musicalComponent.playSound((int)targetKeyId);

                IncrementMeter();
                if (++targetKeyId == LetterKeys.COUNT)
                {
                    if (laps < MiniGameToasts.Length)
                    {
                        sendToast(MiniGameToasts[laps], laps);
                    }
                    if (laps++ == MAX_LAPS) 
                    {
                        BarFullArt.sprite = ApperanceManager.instance.FindMinigameArtByName("RedStarDot");
                    }
                    
                    targetKeyId = LetterKeys.LEFT;
                }
                HilightWhatKeyToPress();
            }
        }
    }

    void CalculateDamage()
    {
        EndAttack((int)(FullDamageValue * Mathf.Clamp((laps / MAX_LAPS), (laps / MAX_LAPS), 1f)));
        areControlsLocked = true;
    }

    void EndAttack(int damage) 
    {
        DamageValue = Mathf.CeilToInt(damage);
        TimerManager.Instance.createTimer(0.3f, EndActivityTimerCountDown); 
    }

    void HilightWhatKeyToPress()
    {
        OnScreenKeyPrompts[(int)targetKeyId].color = Color.white;
        OnScreenKeyPrompts[((int)targetKeyId + ((int)LetterKeys.COUNT -1)) % (int)LetterKeys.COUNT].color = Color.grey;
    }

    void IncrementMeter()
    {
        DonenessBarContent.value++; 
    }
}
