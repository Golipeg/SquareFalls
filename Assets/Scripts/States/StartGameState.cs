using IngameStateMachine;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine.SceneManagement;
using static GlobalConstants;

namespace States
{
    public class StartGameState : IState

    {
        private StateMachine _stateMachine;
        private CompositeDisposable _subscriptions;

        public void Dispose()
        {
        }

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            SceneManager.LoadScene(START_SCENE);
            _subscriptions = new CompositeDisposable()
            {
                EventStreams.EventBus.Subscribe<StartGameEvent>(_ => _stateMachine.Enter<GameState>())
            };
        }

        public void OnExit()
        {
            _subscriptions.Dispose();
        }
    }
}