using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkAnimations : MonoBehaviour
{
  [SerializeField]
  private Animator _animator;
  public void OnMove(InputValue value)
  {
    var move = value.Get<Vector2>();

    if (move == Vector2.zero)
    {
      _animator.SetBool("Up", false);
      _animator.SetBool("Down", false);
      _animator.SetBool("Left", false);
      _animator.SetBool("Right", false);
    }
    else if (move == Vector2.left)
    {
      _animator.SetBool("Left", true);
    }
    else if (move == Vector2.right)
    {
      _animator.SetBool("Right", true);
    }
    else if(move == Vector2.up)
    {
      _animator.SetBool("Up", true);
    }
    else if (move == Vector2.down)
    {
      _animator.SetBool("Down", true);
    }
  }   
}
