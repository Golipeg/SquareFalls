using System.Collections;
using IngameStateMachine;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalConstants;

namespace DefaultNamespace
{
    public class GameState:IState

    {
        private CompositeDisposable _subscription;
        private StateMachine _stateMachine;
        private readonly ICoroutineRunner _coroutineRunner;
        private WaitForSeconds _waitForSeconds;
        
        public void Dispose()
        {
            
        }

        public GameState(ICoroutineRunner coroutineRunner,int sceneChangeDelay)
        {
            _coroutineRunner = coroutineRunner;
            _waitForSeconds = new WaitForSeconds(sceneChangeDelay);
        }

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;


        }

        public void OnEnter()
        {
            SceneManager.LoadScene(GAME_SCENE);
            _subscription = new CompositeDisposable()
            {
                EventStreams.EventBus.Subscribe<GameOverEvent>(OnPlayerDied)
            };
        }

        private void OnPlayerDied(GameOverEvent eventData)
        {
           _coroutineRunner.StartCoroutine(ChangeStateCoroutine());
        }

        private IEnumerator ChangeStateCoroutine()
        {
            yield return _waitForSeconds;
          _stateMachine.Enter<GameOverState>();
            
        }

        public void OnExit()
        {
            _subscription.Dispose();
        }
    }
}