using System;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class Square : MonoBehaviour
{
    public UnitSide SquareType => _squareType; 
    public int RewardSquarePoint => _rewardSquarePoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationPower;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private UnitSide _squareType;
    [SerializeField] private int _rewardSquarePoint;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private Vector2 _startScale;


    public void Initialize(SquareSettings squareSettings, Vector3 randomSpawnPoint)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer.color = squareSettings.Color;
        _squareType = squareSettings.SquareType;
        _rewardSquarePoint = squareSettings.RewardPerSquare;
        transform.position = randomSpawnPoint;
        _startScale = transform.localScale;

    }

    public void ResetScale()
    {
        transform.localScale = _startScale;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Move()
    {
        _rigidbody2D.rotation += _rotationPower;
        _rigidbody2D.velocity = _direction * _speed;
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void DecreaseScale(Action<Square> onDecreaseScale)
    {
        transform.DOScale(Vector3.zero, 1f).OnComplete(() => onDecreaseScale?.Invoke(this));
    }
}