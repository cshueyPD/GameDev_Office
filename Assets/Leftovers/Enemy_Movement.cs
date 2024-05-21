using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    [SerializeField] float health = 3f;
    [SerializeField] public float hunger = 1f;



    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  bar = GetComponent<floatingHealthBar>();

    }

    // Update is called once per frame
    void Update()
    {
        // Get the target
        //if(!target) 
        //{
        GetTarget();
        //}
        //else
        // {
        RotateTowardsTarget();



        //}






    }

    void FixedUpdate()
    {
        // Move forward
        rb.velocity = transform.up * speed;


    }



    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Pizza"))
        {
            target = GameObject.FindGameObjectWithTag("Pizza").transform;
        }
        else if (GameObject.FindGameObjectWithTag("Food"))
        {
            target = GameObject.FindGameObjectWithTag("Food").transform;
        }

    }


    private void RotateTowardsTarget()
    {

        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            target = null;
            gameManager.Instance.EndGame();
        }
        else if (other.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(other.gameObject.GetComponent<Projectile_Motion>().damage);

            if (other.gameObject.GetComponent<Projectile_Motion>().isExplosive)
            {
                other.gameObject.GetComponent<Projectile_Motion>().splashDamage();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ScoreManager.Instance.AddScore(1);
            FindObjectOfType<Score>().UpdateScore();
            Destroy(gameObject);
        }
    }
}
