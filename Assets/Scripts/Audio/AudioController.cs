using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using static GlobalConstants;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {

        [SerializeField] private Image _soundImage;
        [SerializeField] private Sprite _activeSoundSprite;
        [SerializeField] private Sprite _unactiveSoundSprite;
        private int _soundVolume;

        private void Awake()
        {

            _soundVolume = PlayerPrefs.GetInt(SOUND_ENABLE, 1);
            SetSoundVolume();

        }

        private void SetSoundVolume()
        {
            AudioListener.volume = _soundVolume;
            _soundImage.sprite = _soundVolume == 1 ? _activeSoundSprite : _unactiveSoundSprite;
        }

        [UsedImplicitly]
        public void ChangeSoundVolume()
        {
            _soundVolume = +_soundVolume == 1 ? 0 : 1;
            SetSoundVolume();
            SaveSoundVolume();

        }

        private void SaveSoundVolume()
        {
            PlayerPrefs.SetInt(SOUND_ENABLE, _soundVolume);
            PlayerPrefs.Save();
        }
    }
}