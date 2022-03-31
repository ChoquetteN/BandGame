using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MiniGame : MonoBehaviour, iActivity
{
    [SerializeField]
    protected Image MiniGameBackground;

    protected MusicalComponent musicalComponent;

    readonly string[] miniGameToasts = { "Cool", "Great", "Rad", "Hype", "Powerful", "Ultimate" };
    protected string[] MiniGameToasts { get { return miniGameToasts; } }

    protected enum LetterKeys { LEFT, DOWN, RIGHT, UP, COUNT };

    public enum MiniGameType { HAMMER, WHIRLED, MEMORY, NONE };
    public abstract MiniGameType miniGameType { get; }
    public PlayerController.ActivityControlType controlForActivity { get { return PlayerController.ActivityControlType.MINIGAME; } set { } }

    public delegate void onMiniGameEnd(float damage);
    public onMiniGameEnd OnMiniGameEnd;

    protected Vector3 menuStartPosition;
    protected Vector3 menuCurPosition;
    protected Vector3 menuEndPosition;
    protected Vector3 menuTargetPosition;

    public int FullDamageValue { get; set; }
    protected int DamageValue;
    public List<string> noteName { get; set; }

    void Update()
    {
        MiniGameFlyIn();
    }

    public void setInstrument(string instrument)
    {
        if (musicalComponent == null) { musicalComponent = new MusicalComponent(); }
        musicalComponent.instrumentName = instrument;
    }

    public void HideActivity()
    {
        OnMiniGameEnd.Invoke(DamageValue);
        this.gameObject.SetActive(false);
    }

    public virtual void Down() { }

    public virtual void Left() { }

    public virtual void Right() { }

    public virtual void Up() { }

    public virtual void UpKeyUp() { }

    public virtual void DownKeyUp() { }

    public virtual void LeftKeyUp() { }

    public virtual void RightKeyUp() { }

    public void Select() { }

    public virtual void ShowActivity()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void MiniGameFlyIn()
    {
        MiniGameBackground.transform.position = Vector3.SmoothDamp(MiniGameBackground.transform.position, menuTargetPosition, ref menuCurPosition, 0.2f);
    }

    public void EndActivityTimerCountDown()
    {
        menuTargetPosition = menuStartPosition;
        TimerManager.Instance.createTimer(0.3f, HideActivity);
    }

    protected void sendToast(string messageToSend, int colorIndex)
    {
        ToastPool.Instance.SendToastFromLocation(new Vector3(menuCurPosition.x + 300f, 0, menuCurPosition.z - 20), messageToSend, colorIndex);
    }
}
