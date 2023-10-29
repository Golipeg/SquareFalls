using System;
using Audio;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public event Action<Square.Square> SquareIsCatched;
        [SerializeField] private ParticleSystem _deathEffect;
        private PlayerMovementHandler _playerMovementHandler;
        private PlayerInputHandler _playerInputHandler;

        public void Initialize()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerMovementHandler = GetComponent<PlayerMovementHandler>();
            _playerMovementHandler.Initialize();
        
            _playerInputHandler.DirectionIsChanged += _playerMovementHandler.ChangeDirection;
            _playerInputHandler.DirectionIsChanged += PlayChangeDirectionSound;
            AnimatePlayerSpawn();
        }

        private void AnimatePlayerSpawn()
        {
            var startScale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(startScale, 0.4f);
        }

        private void PlayChangeDirectionSound()
        {
            SoundPlayer.Instance.PlayPlayerMoveSound();
        }

        public void DestroyPlayer()
        {
            SoundPlayer.Instance.PlayPlayerDeathSound();
            var fx = Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out Square.Square square))
            {
                if (square.IsUsed)
                {
                    return;
                }
                SquareIsCatched?.Invoke(square);
                square.IsUsed = true;
                

            }
        }
        void Update()
        {
            _playerMovementHandler.Move();
        }



        private void OnDestroy()
        {
            _playerInputHandler.DirectionIsChanged -= _playerMovementHandler.ChangeDirection;
            _playerInputHandler.DirectionIsChanged -= PlayChangeDirectionSound;
        }
    }
}