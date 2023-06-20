using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisibleByParent : MonoBehaviour
{
  public GameObject Parent;

    // Update is called once per frame
    void Update()
    {
        if(Parent.activeSelf)
        {
          gameObject.SetActive(true);
        }
        else
        {
          gameObject.SetActive(false);
        }
    }
}
