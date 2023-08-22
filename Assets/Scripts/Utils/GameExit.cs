using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameExit : MonoBehaviour
{
    public InputAction exitAction;

    // Start is called before the first frame update
    void Start()
    {
        exitAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(exitAction.triggered)
        {
            Application.Quit();
        }
    }
}
