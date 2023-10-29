using System;
using UnityEngine;

namespace Player
{
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
}
