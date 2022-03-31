using System;
using System.Collections.Generic;
using UnityEngine;

public interface iActivity
{
    void ShowActivity();
    void HideActivity();

    void Up();
    void UpKeyUp();
    void Down();
    void DownKeyUp();
    void Left();
    void LeftKeyUp();
    void Right();
    void RightKeyUp();

    void Select();

    PlayerController.ActivityControlType controlForActivity { get; set; }
}