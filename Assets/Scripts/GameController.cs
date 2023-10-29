using Audio;
using Events;
using Player;
using Score;
using SimpleEventBus;
using Square;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private SquareManager _squareManager;

    private void Awake()
    {

        _playerController.Initialize();
        _squareManager.Initialize();
        _scoreManager.Initialize();
        _scoreManager.ScoreChanged += OnScoreChanged;
        _playerController.SquareIsCatched += OnSquareIsCatched;

    }

    private void OnScoreChanged(int score)
    {
        _scoreView.UpdateScoreView(score);
        if (IsGameOver(score))
        {
            GameOver();
        }

    }

    private void OnSquareIsCatched(Square.Square square)
    {
        _squareManager.ReturnSquareToPool(square);
        _scoreManager.ChangeScore(square.RewardSquarePoint);
        if (square.RewardSquarePoint > 0)
        {
            SoundPlayer.Instance.PlayIncreaseScoreSound();
        }
        else
        {
            SoundPlayer.Instance.PlayDecreaseScoreSound();
        }
    }

       

    private void GameOver()
    {
        _playerController.DestroyPlayer();
        EventStreams.EventBus.Publish<GameOverEvent>(new());
    }

    private bool IsGameOver(int currentScore)
    {
        return currentScore <= 0;
    }

    private void OnDestroy()
    {
        _playerController.SquareIsCatched -= OnSquareIsCatched;
        _scoreManager.ScoreChanged -= OnScoreChanged;
        _squareManager.Dispose();
    }
}