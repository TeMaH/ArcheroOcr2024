using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CharacterController))]
public class EnemyMovement : MovementComponent
{
    [SerializeField] private float moveDuration = 2f;
    [SerializeField] private float waitDuration = 2f;

    private Vector3 _moveDirection;
    
    private float _moveTimer;
    private float _waitTimer;
    
    private bool _isMoving;
    private bool _isWaiting = true;

    private void Start()
    {
        _waitTimer = waitDuration;
    }

    private void Update()
    {
        MoveWaitTimer();
    }

    private void MoveWaitTimer()
    {
        if (_isMoving)
        {
            Move(_moveDirection);

            _moveTimer -= Time.deltaTime;
            if (_moveTimer <= 0)
            {
                _isMoving = false;
                _isWaiting = true;
            }
        }
        else
        {
            if (_isWaiting)
            {
                _waitTimer -= Time.deltaTime;
                if (_waitTimer <= 0)
                {
                    _isWaiting = false;
                    _waitTimer = waitDuration;

                    _isMoving = true;
                    _moveTimer = moveDuration;
                    _moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                }
            }
        }
    }
}