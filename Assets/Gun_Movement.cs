using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Movement : MonoBehaviour
{

    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle =Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg -90f;
        transform.localRotation = Quaternion.Euler (0,0,angle);
    }
}
