using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
  [SerializeField]
  private float MoveSpeed = 4.0f;
  private Vector2 _move = Vector2.zero;

  public void OnMove(InputValue value)
  {
    _move = value.Get<Vector2>();
  }

  private void Update()
  {
    float targetSpeed = MoveSpeed;
    if (_move == Vector2.zero) targetSpeed = 0.0f;
    transform.Translate(_move * targetSpeed * Time.deltaTime);
  }
}
