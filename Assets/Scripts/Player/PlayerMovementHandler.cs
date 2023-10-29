using UnityEngine;

namespace Player
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        [SerializeField] private Transform _leftSideBorder;
        [SerializeField] private Transform _rightSideBorder;
        [SerializeField] private float _speed;
        private float _currentTime;
        private float _oneWayDuration;
        private bool _isMovingRight;

        public void Initialize()
        {
            _oneWayDuration = Vector2.Distance(_leftSideBorder.position, _rightSideBorder.position) / _speed;
        }

        public void Move()
        {
            _currentTime += _isMovingRight ? +Time.deltaTime : -Time.deltaTime;
            var progress = Mathf.PingPong(_currentTime, _oneWayDuration) / _oneWayDuration;
            transform.position = Vector2.Lerp(_leftSideBorder.position, _rightSideBorder.position, progress);
        }

        public void ChangeDirection()
        {
            _isMovingRight = !_isMovingRight;
        }
    }
}