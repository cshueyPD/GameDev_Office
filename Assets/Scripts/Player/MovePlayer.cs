using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 4.0f;
    [SerializeField]
    private float _speedMultiplier = 2.0f;
    private Vector2 _move = Vector2.zero;

    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    public void Sprint(bool isSprinting)
    {
        if (isSprinting)
        {
            _moveSpeed *= _speedMultiplier;
        }
        else
        {
            _moveSpeed /= _speedMultiplier;
        }
    }

    private void Update()
    {
        float targetSpeed = _moveSpeed;
        if (_move == Vector2.zero) targetSpeed = 0.0f;
        transform.Translate(_move * targetSpeed * Time.deltaTime);
    }
}
