using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action DirectionIsChanged;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           DirectionIsChanged?.Invoke(); 
        }
    }
}
