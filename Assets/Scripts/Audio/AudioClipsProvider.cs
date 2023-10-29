using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioClips",menuName = "AudioClips")]
    public class AudioClipsProvider:ScriptableObject

    {
        [field:SerializeField] public AudioClip PlayerDeathClip { get; private set; }
        [field:SerializeField] public AudioClip PlayerTookPointClip { get; private set; }
        [field: SerializeField] public AudioClip PlayerLostPointClip { get; private set; }
        [field:SerializeField] public AudioClip ChangeDirectionClip { get; private set; }
        [field:SerializeField] public AudioClip BestScoreChangeClip { get; private set; }
        
        
    }
}