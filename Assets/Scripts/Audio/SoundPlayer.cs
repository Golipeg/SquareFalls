using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        public static SoundPlayer Instance { get; private set; }

        [SerializeField] private AudioClipsProvider _audioClipsProvider;
        private AudioSource _audioSource;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayPlayerDeathSound() => PlayAudioClip(_audioClipsProvider.PlayerDeathClip);
        public void PlayIncreaseScoreSound() => PlayAudioClip(_audioClipsProvider.PlayerTookPointClip);
        public void PlayDecreaseScoreSound() => PlayAudioClip(_audioClipsProvider.PlayerLostPointClip);
        public void PlayPlayerMoveSound() => PlayAudioClip(_audioClipsProvider.ChangeDirectionClip);
        public void PlayBestScoreChangedSound() => PlayAudioClip(_audioClipsProvider.BestScoreChangeClip);
        private void PlayAudioClip(AudioClip audioClip) => _audioSource.PlayOneShot(audioClip);
    }
}