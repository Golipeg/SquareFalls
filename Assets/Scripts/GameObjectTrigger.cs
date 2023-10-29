using System;
using UnityEngine;

public class GameObjectTrigger : MonoBehaviour
{
    public event Action<Collider2D> ObjectTriggerEntered;

    private void OnTriggerEnter2D(Collider2D col)
    {
        ObjectTriggerEntered?.Invoke(col);
    }
}