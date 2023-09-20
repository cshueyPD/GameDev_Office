using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTarget : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 1.5f; 
    [SerializeField] private float distanceToPlayer = 5f; 

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.transform.position,transform.position)<distanceToPlayer)
        {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.up = target.transform.position - transform.position;
        }
    }
}
