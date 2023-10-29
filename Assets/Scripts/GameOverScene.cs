using System;
using DefaultNamespace;
using SimpleEventBus;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{ 
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitGameButton;
    [SerializeField] private TextMeshProUGUI _bestScoreLabel;

    private void Awake()
    {
        _restartButton.onClick.AddListener(()=>EventStreams.EventBus.Publish(new RestartGameEvent()));
        _exitGameButton.onClick.AddListener(()=>EventStreams.EventBus.Publish(new ExitGameEvent()));
        ShowBestScore();
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveAllListeners();
        _exitGameButton.onClick.RemoveAllListeners();
    }

    private void ShowBestScore()
    {
       var bestScore= PlayerPrefs.GetInt(GlobalConstants.BEST_SCORE_KEY);
       _bestScoreLabel.text = $"BEST SCORE :{bestScore}";

    }
}
