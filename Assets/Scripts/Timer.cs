using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    Action action;

    float curTime;

    public bool isActive = false;

    public Timer SetTimer(float time, Action action)
    {
        curTime = time;
        this.action = action;
        isActive = true;
        return this;
    }

    public void countDown()
    {
        curTime -= Time.deltaTime;
        if (curTime <= 0)
        {
            action.Invoke();
            isActive = false;
        }
    }  

    public void StopTimer()
    {
        isActive = false;
    }

}
