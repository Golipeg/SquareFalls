using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class SquarePool
    {
        private readonly Queue<Square> _squarePool = new();
        private readonly Square _squarePrefab;
        private readonly Transform _parentRoot;

        public SquarePool(Square prefab, Transform parentRoot, int initPoolSize = 15)
        {
            _squarePrefab = prefab;
            _parentRoot = parentRoot;
            for (var i = 0; i < initPoolSize; i++)
            {
                CreateNewSquare();
            }
        }

        public Square GetSquare()
        {
            if (_squarePool.Count == 0)
            {
                CreateNewSquare();
            }

            var square = _squarePool.Dequeue();
            square.gameObject.SetActive(true);
            return square;
        }

        public void ReturnSquare(Square square)
        {
            square.gameObject.SetActive(false);
            _squarePool.Enqueue(square);
        }

        private void CreateNewSquare()
        {
            var square = Object.Instantiate(_squarePrefab, _parentRoot);
            square.gameObject.SetActive(false);
            _squarePool.Enqueue(square);
        }
    }
}