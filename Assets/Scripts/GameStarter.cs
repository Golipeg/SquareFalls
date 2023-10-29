using IngameStateMachine;
using States;
using UnityEngine;

public class GameStarter : MonoBehaviour,ICoroutineRunner
{
    private StateMachine _stateMachine;
    private const int SCENE_CHANGE_DELAY = 1;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        var startState = new StartGameState();
        var gameState = new GameState(this,SCENE_CHANGE_DELAY);
        var gameOverState = new GameOverState();
        _stateMachine = new StateMachine(startState,gameState,gameOverState);
        _stateMachine.Initialize();
        _stateMachine.Enter<StartGameState>();
    }

    private void OnDestroy()
    {
        _stateMachine.Dispose();
    }
}