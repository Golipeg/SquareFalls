using SimpleEventBus;
using States;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] private Button _startButton;
        

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGameEvent);
    }

    private void StartGameEvent()
    {
        EventStreams.EventBus.Publish(new StartGameEvent());
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveAllListeners();
    }
}