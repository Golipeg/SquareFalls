using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "SquareSettings", menuName = "SquareSettings")]
    public class SquareSettings : ScriptableObject
    {
        [field: SerializeField] public Color Color { get; private set; }
        [field: SerializeField] public UnitSide SquareType { get; private set; }
        [field: SerializeField] public int RewardPerSquare { get; private set; }
    }
}