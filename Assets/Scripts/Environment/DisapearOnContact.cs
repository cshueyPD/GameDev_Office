using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearOnContact : MonoBehaviour
{
    public SO_Event collected;
    private void OnCollisionEnter2D(Collision2D other) {
      Debug.Log($"Collision Enter: {other.gameObject.tag}");
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            collected.Raise();
        }
    }
}
