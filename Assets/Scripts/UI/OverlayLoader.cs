using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayLoader : MonoBehaviour
{
    [SerializeField]
    private SceneChanger SceneOverlay;

    // Start is called before the first frame update
    void Start()
    {
        SceneOverlay.AddToScene();
    }
}
