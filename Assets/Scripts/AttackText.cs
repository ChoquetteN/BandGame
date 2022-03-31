using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackText : MonoBehaviour, iActivity
{

    public delegate void OnTimerEnd(float damage);
    public OnTimerEnd onTimerEnd;

    [SerializeField]
    Text AttackName;

    const float maxTime = 1.5f;

    float damage; 

    public PlayerController.ActivityControlType controlForActivity { get { return PlayerController.ActivityControlType.NO_INPUT; } set { } }

    public void LabelAttack(string attackName , float damage)
    {
        AttackName.text = attackName;
        this.damage = damage;
    }

    public void ShowActivity()
    {
        this.gameObject.SetActive(true);
        TimerManager.Instance.createTimer(maxTime, HideActivity);
    }

    public void HideActivity()
    {
        this.gameObject.SetActive(false);
        onTimerEnd.Invoke(damage);
    }

    public void Up()
    {
       
    }

    public void UpKeyUp()
    {
       
    }

    public void Down()
    {
       
    }

    public void DownKeyUp()
    {
       
    }

    public void Left()
    {
      
    }

    public void LeftKeyUp()
    {
       
    }

    public void Right()
    {
       
    }

    public void RightKeyUp()
    {
        
    }

    public void Select()
    {
       
    }
}
