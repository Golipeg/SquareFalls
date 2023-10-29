using System;
using UnityEngine;

namespace Square
{
    [Serializable]
    public class SquareSettingsProvider 
    {
        [field:SerializeField] public SquareSettings EnemySettings { get; private set; }
        [field:SerializeField] public SquareSettings AllySettings { get; private set; }
        
    }
}