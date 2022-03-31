using UnityEngine;
using UnityEngine.UI;

public class Hammer : MiniGame
{
    [SerializeField]
    Image[] OnScreenColoredDotTimer;

    Sprite[] ColoredDotArray = new Sprite[4];

    [SerializeField]
    Image ControllerButtonImage;

    // maxTime, When this expires the attack ends
    const float maxTime = 4;

    //Time in between each dot, between forth and end is strike time
    float intervalTime;

    int index;

    public override MiniGameType miniGameType { get { return MiniGame.MiniGameType.HAMMER; } }

    Timer timer;

    private void Start()
    {
        musicalComponent.addNote(0, "C2");
        musicalComponent.addNote(1, "A2");
        menuEndPosition = new Vector3(MiniGameBackground.transform.position.x, MiniGameBackground.transform.position.y, MiniGameBackground.transform.position.z);
        ColoredDotArray[0] = ApperanceManager.instance.FindMinigameArtByName("GreenDot");
        ColoredDotArray[1] = ApperanceManager.instance.FindMinigameArtByName("YellowDot");
        ColoredDotArray[2] = ApperanceManager.instance.FindMinigameArtByName("RedDot");
        ColoredDotArray[3] = ApperanceManager.instance.FindMinigameArtByName("RedStarDot");
        intervalTime = maxTime / (OnScreenColoredDotTimer.Length * 2);
        menuStartPosition = new Vector3(-Camera.main.pixelWidth - MiniGameBackground.rectTransform.rect.size.x, MiniGameBackground.transform.position.y, MiniGameBackground.transform.position.z);
        menuTargetPosition = menuEndPosition;
        MiniGameBackground.transform.position = menuStartPosition;     
    }

    void nextDot()
    {
        if (index == OnScreenColoredDotTimer.Length)
        {
            CalculateDamage(false);
        }
        else
        {
            OnScreenColoredDotTimer[index].sprite = ColoredDotArray[index];
            index++;
            if (index == OnScreenColoredDotTimer.Length)
            {
                ControllerButtonImage.color = Color.white;
                musicalComponent.playSound(1);
            }
            else
                musicalComponent.playSound(0);
                timer = TimerManager.Instance.createTimer(intervalTime, nextDot);
        }
    }

    public override void ShowActivity()
    {
        resetDots();
        index = 0;
        menuTargetPosition = menuEndPosition;
        ControllerButtonImage.sprite = ApperanceManager.instance.FindMinigameArtByName("A_Key_Up");
        base.ShowActivity();
    }

    void resetDots()
    {
        foreach (Image i in OnScreenColoredDotTimer)
        {
            i.sprite = ApperanceManager.instance.FindMinigameArtByName("BlankSpace");
        }
        OnScreenColoredDotTimer[OnScreenColoredDotTimer.Length-1].sprite = ApperanceManager.instance.FindMinigameArtByName("StarDot");
    }

    public override void Left()
    {
        ControllerButtonImage.color = Color.gray;
        timer = TimerManager.Instance.createTimer(intervalTime, nextDot);
    }

    void CalculateDamage(bool fullDamage)
    {
        DamageValue = FullDamageValue;
        timer.StopTimer();
        TimerManager.Instance.createTimer(0.3f, EndActivityTimerCountDown);
        if (!fullDamage) { DamageValue /= 3; }
        else
        sendToast(MiniGameToasts[2], 2);
    }

    public override void LeftKeyUp()
    {
        CalculateDamage(index == OnScreenColoredDotTimer.Length);
    }
}
