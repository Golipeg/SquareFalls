using System;
using DefaultNamespace.FX;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public event Action<Square> SquareIsCatched;
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
        var changeDirectionSound = GameFXHandler.Instance.AudioClipsProvider.ChangeDirectionSound;
        GameFXHandler.Instance.PlayAudioEffect(changeDirectionSound);
    }

    public void DestroyPlayer()
    {
        GameFXHandler.Instance.PlayDeathAnimation();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Square square))
        {
            SquareIsCatched?.Invoke(square);

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