using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Square
{
    public class SquareManager : MonoBehaviour,IDisposable
    {
        [SerializeField] private SquareSettingsProvider _settingsProvider;
        [SerializeField] private Square _squarePrefab;
        [SerializeField] private float _maxSpawnTime;
        [SerializeField] private float _minSpawnTime;
        [SerializeField] private GameObjectTrigger _returnTrigger;
        private SquarePositionHandler _squarePositionHandler;
        private SquarePool _squarePool;
        private float _delayBetweenSpawn;
        private float _chanceSquareType = 0.3f;

        public void Initialize()
        {
            _squarePool = new SquarePool(_squarePrefab, transform);
            _returnTrigger.ObjectTriggerEntered+= OnObjectTriggerEntered;
            _squarePositionHandler = GetComponent<SquarePositionHandler>();
        }

        private void OnObjectTriggerEntered(Collider2D collider)
        {
            if (collider.TryGetComponent(out Square square))
            {
                square.DecreaseScale(OnDecreaseScale);
            }
        }

        private void OnDecreaseScale(Square square)
        {
            _squarePool.ReturnSquare(square);
            square.ResetScale();
        }

        private Square SpawnSquare()
        {
            var square = _squarePool.GetSquare();
            var randomValue = Random.value;
            var squareSettings = randomValue <= _chanceSquareType ? _settingsProvider.EnemySettings: _settingsProvider.AllySettings;
            var randomSpawnPoint = _squarePositionHandler.GetRandomSpawnPoint();
            square.Initialize(squareSettings,randomSpawnPoint);
            return square;
        }

        private void Update()
        {
            if (_delayBetweenSpawn <= 0)
            {
                var square = SpawnSquare();
                var targetDirection =_squarePositionHandler.GetRandomDirection(square.transform.position);
                square.SetDirection(targetDirection);
                _delayBetweenSpawn = Random.Range(_minSpawnTime, _maxSpawnTime);
            }

            _delayBetweenSpawn -= Time.deltaTime;
        }
        public void Dispose()
        {
        
            _returnTrigger.ObjectTriggerEntered-= OnObjectTriggerEntered;
        }

        public void ReturnSquareToPool(Square square)
        {
        
            square.DecreaseScale(OnDecreaseScale);
        }
    }
}