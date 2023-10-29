using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _scoreText.text = 0.ToString();
        }

        public void UpdateScoreView(int score)
        {
            _scoreText.text = score.ToString();
            _scoreText.transform.DOShakeScale(0.5f);
        }
    }
}