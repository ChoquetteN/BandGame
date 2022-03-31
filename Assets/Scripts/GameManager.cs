using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    StartMenu startMenu;

    List<Character> CharactersInBattle;

    [SerializeField]
    SpriteRenderer[] playerPositions;

    public SpriteRenderer[] PlayerPositions { get { return playerPositions; } private set{ } }

    [SerializeField]
    SpriteRenderer[] rivalPositions;

    public SpriteRenderer[] RivalPositions { get { return rivalPositions; } private set { } }

    Character CurCharacter;

    [SerializeField]
    CombatMenu Menu;

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    Guage audienceGuage;

    [SerializeField]
    CharacterTurnManager turnManager;

    CharacterFactory characterFactory;

    [SerializeField]
    MiniGameManager miniGameManager;

    [SerializeField]
    AttackText attackText;

    [SerializeField]
    CameraManager camera;

    [SerializeField]
    Image endGameBackground;

    private void Awake()
    {
        startMenu.startGame = new StartGameCommand("Let's Rock!", StartGame);
        playerController.SwapActivity(startMenu);
        startMenu.SetTitleText("HEROES OF MIGHT AND MIDI");
        startMenu.SetDescription("WASD for menu navigation \n \n Enter to select things \n \n Press esc to quit at any time \n \n a demo by Ghostbrother");
    }

    void StartGame()
    {
        audienceGuage.SetScoreToZero();
        startMenu.StartGame();
        audienceGuage.onGameWin = onWinGame;
        audienceGuage.onGameLose = onLoseGame;
        characterFactory = new CharacterFactory();
        turnManager.LoadCharacterList(characterFactory.LoadMoves(this));
        DrawNextCharacter();
        audienceGuage.OnGuageStop = DrawNextCharacter;
    }

    void onWinGame()
    {
        startMenu.startGame = new StartGameCommand("Play again!", StartGame);
        playerController.SwapActivity(startMenu);

        startMenu.SetTitleText("You Won!");
        startMenu.SetDescription("Too cool! Thank you so much for \n playing my demo.");
    }

    void onLoseGame()
    {
        startMenu.startGame = new StartGameCommand("Try again!", StartGame);
        playerController.SwapActivity(startMenu);
        startMenu.SetTitleText("You lost...");
        startMenu.SetDescription("Aww man! Thank you so much \n for playing my demo.");
    }

    void DrawNextCharacter()
    {
        camera.MoveCameraToStartPositionAndSize();
        CurCharacter = turnManager.LoadNextCharacter();
        CurCharacter.onTurnStart.Invoke(CurCharacter.CharacterMoves);
    }

    public void PopulateMenu(List<Moves> characterMoves)
    {
        Menu.setInstrument(CurCharacter.Instrument);
        Menu.PopulateMenu(characterMoves);
        playerController.SwapActivity(Menu);
    }

    void EndMiniGame(float damage)
    {
        audienceGuage.PlayerScorePoints(damage);
    }

    public void switchToMenu()
    {
        playerController.SwapActivity(Menu);
        camera.MoveCameraToStartPositionAndSize();
        DrawNextCharacter();
    }

    public void switchToMiniGame(AttackAction attack)
    {
        camera.AssignTarget(CurCharacter.coasterTransform.position); 
        MiniGame mg = miniGameManager.FindMiniGameByName(attack._MiniGameType);
        mg.setInstrument(CurCharacter.Instrument);
        camera.SetZoomDistance(PlayerPositions[0].sprite.bounds.size.x);
        mg.OnMiniGameEnd = EndMiniGame;
        mg.FullDamageValue = attack.damageValue;
        playerController.SwapActivity(mg);
    }

    public void displayAttack(AttackAction attack)
    {
        camera.AssignTarget(CurCharacter.coasterTransform.position);
        camera.SetZoomDistance(PlayerPositions[0].sprite.bounds.size.x);
        attackText.onTimerEnd = RivalScorePoints;
        attackText.LabelAttack(attack.MoveName, attack.damageValue);
        playerController.SwapActivity(attackText);
    }

    void RivalScorePoints(float damage)
    {
        audienceGuage.RivalScorePoints(damage);
    }
}
