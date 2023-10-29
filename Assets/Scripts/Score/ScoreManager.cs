using System;
using UnityEngine;
using static GlobalConstants;

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        private int _currentScore;
        private int _bestScore;

        public void Initialize()
        {
            _currentScore = 0;
            _bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY,0);
            PlayerPrefs.SetInt(IS_BEST_SCORE_CHANGED_KEY,0);
        
        }
    
        public void ChangeScore(int score)
        {
            _currentScore += score;
            UpdateBestScore(_currentScore);
            ScoreChanged?.Invoke(_currentScore);

        }

        private void UpdateBestScore(int newScore)
        {
            if (newScore > _bestScore)
            {
                PlayerPrefs.SetInt(IS_BEST_SCORE_CHANGED_KEY,1);
                _bestScore = newScore;
            }
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY,_bestScore);
            PlayerPrefs.Save(); 
        }
    }
}