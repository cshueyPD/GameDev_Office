using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float projectileSpeed = 10f;

    Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Vector2 force = transform.right;
    }
}
