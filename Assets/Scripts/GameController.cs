using DefaultNamespace.FX;
using SimpleEventBus;
using UnityEngine;

namespace DefaultNamespace
{
    //  TODO получение очков, 3. уменьшение очков  4. звук обновления BestScore
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

        private void OnSquareIsCatched(Square square)
        {
            _squareManager.ReturnSquareToPool(square);
            _scoreManager.ChangeScore(square.RewardSquarePoint);
            if (square.RewardSquarePoint > 0)
            {
                PlayIncreaseScoreSound();
            }
            else
            {
                PlayDecreaseScoreSound();
            }
        }

        private void PlayIncreaseScoreSound()
        {
            var increaseScoreSound = GameFXHandler.Instance.AudioClipsProvider.PlayerTookPoint;
            GameFXHandler.Instance.PlayAudioEffect(increaseScoreSound);
        }

        private void PlayDecreaseScoreSound()
        {
            var decreaseScoreSound = GameFXHandler.Instance.AudioClipsProvider.PlayerLostPoint;
            GameFXHandler.Instance.PlayAudioEffect(decreaseScoreSound);
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
}