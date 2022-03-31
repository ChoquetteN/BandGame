using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guage : MonoBehaviour
{
    public Action onGameWin;

    public Action onGameLose;

    private const float PLAYER_WIN_NUM = 90;

    private const float PLAYER_LOSE_NUM = -90;

    private const float startPositionScore = 0;

    float currentScore = 0;

    [SerializeField]
    Transform curArrowRotation;

    Vector3 desiredArrowRotation;

    // on activity end?
    public delegate void onGuageStop();
    public onGuageStop OnGuageStop;

    bool isArrowMoving = false;

    void Update()
    {
        curArrowRotation.rotation = Quaternion.Lerp(curArrowRotation.rotation, Quaternion.Euler(desiredArrowRotation), Time.deltaTime * 2f);  

        if(isArrowMoving && curArrowRotation.rotation == Quaternion.Euler(desiredArrowRotation))
        {
            OnGuageStop.Invoke();
            isArrowMoving = false;
        }
    }

    public void SetScoreToZero()
    {
        isArrowMoving = false;
        currentScore = startPositionScore;
        desiredArrowRotation = new Vector3(0, 0, 0);
        curArrowRotation.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
    }

    public void PlayerScorePoints(float points)
    {
        currentScore += points;
        desiredArrowRotation = new Vector3(0, 0, RotateArrow());
        if (desiredArrowRotation.z == PLAYER_LOSE_NUM - currentScore /  PLAYER_LOSE_NUM - PLAYER_WIN_NUM)
        {
            OnGuageStop.Invoke();
        }
        if(currentScore >= PLAYER_WIN_NUM)
        {
            OnGuageStop = onGameWin.Invoke; 
        }
    }

    public void RivalScorePoints(float points)
    {
        currentScore -= points;
        desiredArrowRotation = new Vector3(0, 0, RotateArrow());

        if (PLAYER_LOSE_NUM >= currentScore)
        {
            OnGuageStop = onGameLose.Invoke;
        }
    }

    float RotateArrow()
    {
        float totalAngle = 0 - PLAYER_WIN_NUM; // zero was PLAYER_LOSE_NUM 
        float speedNormalized = currentScore / 90;
        isArrowMoving = true;
        return 0 - speedNormalized * totalAngle; // zero was PLAYER_LOSE_NUM 
    }
}
