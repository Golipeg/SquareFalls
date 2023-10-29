using Events;
using IngameStateMachine;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalConstants;

namespace States
{
    public class GameOverState:IState

    {
        private CompositeDisposable _subscription;
        private StateMachine _stateMachine;
        
        public void Dispose()
        {
            
        }
        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            SceneManager.LoadScene(GAME_OVER_SCENE);
            
            _subscription = new CompositeDisposable()
            {
             EventStreams.EventBus.Subscribe<RestartGameEvent>(RestartGame),
             EventStreams.EventBus.Subscribe<ExitGameEvent>(ExitGame)
             
            };
        }

        private void ExitGame(ExitGameEvent obj)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
        
        }

        private void RestartGame(RestartGameEvent obj)
        {
            _stateMachine.Enter<GameState>();
        }

        public void OnExit()
        {
            _subscription.Dispose();
        }
    }
}