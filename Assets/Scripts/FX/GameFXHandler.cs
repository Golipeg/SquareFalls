using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.FX
{
    public class GameFXHandler:MonoBehaviour

    {
        public static GameFXHandler Instance { get; private set; }
        public AudioClipsProvider AudioClipsProvider => _audioClipsProvider;
        [SerializeField] private AudioClipsProvider _audioClipsProvider;
        [SerializeField] private ParticleSystem _deathEffect;


        private void Awake()
        {
            if (Instance !=null && Instance!=this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public void PlayDeathAnimation()
        {
            var fx = Instantiate(_deathEffect, transform.position, Quaternion.identity);
            PlayAudioEffect(_audioClipsProvider.PlayerDeathClip);
           
        }

        public void PlayAudioEffect(AudioClip audioClip)
        {
            var audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource.AddComponent<AudioSource>();
            }

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        
    }
}