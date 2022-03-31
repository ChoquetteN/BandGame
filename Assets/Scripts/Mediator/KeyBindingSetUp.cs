using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyBindingSetUp : MonoBehaviour
{
    Dictionary<PlayerController.ActivityControlType, Dictionary<KeyCode, AssignableCommand>> BindingBasedOnActivity;

    public KeyBindingSetUp()
    {
        init();
    }

    void init()
    {
        BindingBasedOnActivity = new Dictionary<PlayerController.ActivityControlType, Dictionary<KeyCode, AssignableCommand>>();


        Dictionary<KeyCode, AssignableCommand> _controllerMaping = new Dictionary<KeyCode, AssignableCommand>();
        _controllerMaping.Add(KeyCode.D, new MoveRight());
        _controllerMaping.Add(KeyCode.A, new MoveLeft());
        _controllerMaping.Add(KeyCode.Return, new Select());
        _controllerMaping.Add(KeyCode.Escape, new ExitGame());

        BindingBasedOnActivity.Add(PlayerController.ActivityControlType.START_MENU, _controllerMaping);


        _controllerMaping = new Dictionary<KeyCode, AssignableCommand>();
        _controllerMaping.Add(KeyCode.W, new MoveUp());
        _controllerMaping.Add(KeyCode.S, new MoveDown());
        _controllerMaping.Add(KeyCode.Return, new Select());
        _controllerMaping.Add(KeyCode.Escape, new ExitGame());

        BindingBasedOnActivity.Add(PlayerController.ActivityControlType.MENU, _controllerMaping);

        _controllerMaping = new Dictionary<KeyCode, AssignableCommand>();

        _controllerMaping.Add(KeyCode.W, new MoveUp());
        _controllerMaping.Add(KeyCode.S, new MoveDown());
        _controllerMaping.Add(KeyCode.D, new MoveRight());
        _controllerMaping.Add(KeyCode.A, new MoveLeft());
        _controllerMaping.Add(KeyCode.Return, new Select());
        _controllerMaping.Add(KeyCode.Escape, new ExitGame());


        BindingBasedOnActivity.Add(PlayerController.ActivityControlType.MINIGAME, _controllerMaping);

        _controllerMaping = new Dictionary<KeyCode, AssignableCommand>();
        _controllerMaping.Add(KeyCode.Escape, new ExitGame());
        BindingBasedOnActivity.Add(PlayerController.ActivityControlType.NO_INPUT, _controllerMaping);

    }

    public Dictionary<KeyCode, AssignableCommand> FindControlSchemeBasedOnActivityType(PlayerController.ActivityControlType ActivityType)
    {
        return BindingBasedOnActivity[ActivityType];
              
    }
}
