using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameObjectTrigger : MonoBehaviour
    {
        public event Action<Collider2D> ObjectTriggerEntered;

        private void OnTriggerEnter2D(Collider2D col)
        {
            ObjectTriggerEntered?.Invoke(col);
        }
    }
}