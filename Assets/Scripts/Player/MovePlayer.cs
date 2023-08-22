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

    public Animator animator;


    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>().normalized;
       animator.SetFloat("Horizontal", value.Get<Vector2>().x);
       animator.SetFloat("Vertical",value.Get<Vector2>().y);
       animator.SetFloat("Speed",value.Get<Vector2>().sqrMagnitude);
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
