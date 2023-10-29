using UnityEngine;

namespace Square
{
    public class SquarePositionHandler : MonoBehaviour
    {
        [ SerializeField] public Transform _leftSpawnPoint;
        [ SerializeField] public Transform _rightSpawnPoint;
        [SerializeField] private Transform _rightLineBorder;
        [SerializeField] private Transform _leftLineBorder;
        
        
        public Vector3 GetRandomSpawnPoint()
        {
            return GetRandomPoint(_leftSpawnPoint.position, _rightSpawnPoint.position);
            
        }


        public Vector3 GetRandomDirection(Vector3 currentPosition)
        {
            var targetPosition = GetRandomPoint(_leftLineBorder.position, _rightLineBorder.position);
            var targetDirection = targetPosition - currentPosition;
            return targetDirection;
        }

        private Vector3 GetRandomPoint(Vector3 leftPoint,Vector3 rightPoint)
        {
            var randomProgress = Random.Range(0f, 1f);
            var currentPoint = Vector3.Lerp(leftPoint, rightPoint, randomProgress);
            return currentPoint;
        }
    }
}