using UnityEngine;

namespace DefaultNamespace.FX
{
    [CreateAssetMenu(fileName = "AudioClips",menuName = "AudioClips")]
    public class AudioClipsProvider:ScriptableObject

    {
        [field:SerializeField] public AudioClip PlayerDeathClip { get; private set; }
        [field:SerializeField] public AudioClip PlayerTookPoint { get; private set; }
        [field: SerializeField] public AudioClip PlayerLostPoint { get; private set; }
        [field:SerializeField] public AudioClip ChangeDirectionSound { get; private set; }
        
    }
}