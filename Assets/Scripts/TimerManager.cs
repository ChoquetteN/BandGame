using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    static TimerManager instance;

    public static TimerManager Instance { get { return instance; } }

    static System.Object padLock = new System.Object();

    static List<Timer> TimerList;


    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        initPool();
    }

    private void Update()
    {
        foreach(Timer t in TimerList)
        {
            if(t.isActive)
            {
                t.countDown();
            }
        }
    }

    public Timer createTimer(float time, Action action)
    {
        foreach(Timer t in TimerList)
        {
            if(!t.isActive)
            {
                t.SetTimer(time, action);
                return t;
            }
        }
        Timer timerToAdd = new Timer();
        TimerList.Add(timerToAdd);
        timerToAdd.SetTimer(time, action);
        return timerToAdd;
    }

    public void StopTimer(Timer timer)
    {
        timer.StopTimer();
    }

     void initPool()
    {
        TimerList = new List<Timer>();
        for (int i = 0; i < 20; i++)
        {
            TimerList.Add(new Timer());
        }
    }
}
