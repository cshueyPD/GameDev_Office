using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Motion : MonoBehaviour
{
    [Range(1, 20)]
    [SerializeField] private float speed = 10f;

    [Range(0.1f, 1f)]
    public float fireRate = 0.5f;

    [Range(1, 10)]
    [SerializeField] private float lifetime = 3f;
    public float damage = 1f;

    [SerializeField] public bool isExplosive;
    public float splash = 3f;

    private Rigidbody2D rb;

    [SerializeField] private ParticleSystem explosionParticles;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }


    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    public void splashDamage()
    {
        Debug.Log("Splash Damage");

        StartCoroutine("CreateAndDestroySprite");


        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, 4f);
            foreach (var c in colliders)
            {
                //Apply damage to enemies
                if (c.gameObject.CompareTag("Enemy"))
                {
                    c.gameObject.GetComponent<Enemy_Movement>().TakeDamage(splash);
                    Debug.Log("Enemy Hit");

                }
            }
        }
    }

    IEnumerator CreateAndDestroySprite()
    {
        // GameObject spriteInstance = Instantiate(SpritePrefab, transform.position, Quaternion.identity);
        explosionParticles.Play();
        yield return new WaitForSeconds(0.1f);
        // Destroy(spriteInstance);
        Destroy(gameObject);

    }
}
