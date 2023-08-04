using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _speedMultiplier = 2.0f;


    public void OnMove(InputValue value)
    {
        var move = value.Get<Vector2>();

        // if (move == Vector2.zero)
        // {
        //     _animator.SetInteger("Direction", (int) Direction.STOP);
        // }
        if (move == Vector2.left)
        {
            _animator.SetInteger("Direction", (int)Direction.LEFT);
        }
        else if (move == Vector2.right)
        {
            _animator.SetInteger("Direction", (int)Direction.RIGHT);
        }
        else if (move == Vector2.up)
        {
            _animator.SetInteger("Direction", (int)Direction.UP);
        }
        else if (move == Vector2.down)
        {
            _animator.SetInteger("Direction", (int)Direction.DOWN);
        }
        else
        {
            _animator.SetInteger("Direction", (int)Direction.STOP);
        }
        // Debug.Log($"Move: {move}");
    }

    public void Sprint(bool isSprinting)
    {
        if (isSprinting)
        {
            _animator.speed *= _speedMultiplier;
        }
        else
        {
            _animator.speed /= _speedMultiplier;
        }
    }
}

public enum Direction
{
    STOP = 0,
    UP,
    RIGHT,
    DOWN,
    LEFT,
}