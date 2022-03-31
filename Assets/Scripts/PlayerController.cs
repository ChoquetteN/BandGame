using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, iActivitySubject
{
    public enum ActivityControlType { START_MENU, MENU, MINIGAME, NO_INPUT};

    iActivity curActivity;

    Dictionary<KeyCode, AssignableCommand> _controllerMaping;

    KeyBindingSetUp keyBindings;

    public void SwapActivity(iActivity newActivity)
    {
        curActivity = newActivity;
        if (keyBindings == null) { keyBindings = new KeyBindingSetUp();}
         newActivity.ShowActivity();
        _controllerMaping = keyBindings.FindControlSchemeBasedOnActivityType(curActivity.controlForActivity);
        Notify();
    }

    public void Notify()
    {
        foreach(KeyValuePair<KeyCode,AssignableCommand> keyValuePair in _controllerMaping)
        {
            keyValuePair.Value.UpdateObserver(curActivity);
        }
    }

    private void Update()
    {
        foreach (KeyValuePair<KeyCode, AssignableCommand> keyValuePair in _controllerMaping)
        {
            if (Input.GetKeyDown(keyValuePair.Key))
                keyValuePair.Value.Execute();
            if (Input.GetKeyUp(keyValuePair.Key))
                keyValuePair.Value.KeyUp();
        }
    }

}
