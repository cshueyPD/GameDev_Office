using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] projectileObjects;
    private void Update()
    {
        switch (gameManager.Instance.currentProjectile)
        {
            case ProjectileType.RED:
                projectileObjects[0].SetActive(true);
                projectileObjects[1].SetActive(false);
                projectileObjects[2].SetActive(false);
                break;
            case ProjectileType.GREEN:
                projectileObjects[0].SetActive(false);
                projectileObjects[1].SetActive(true);
                projectileObjects[2].SetActive(false);
                break;
            case ProjectileType.DONUT:
                projectileObjects[0].SetActive(false);
                projectileObjects[1].SetActive(false);
                projectileObjects[2].SetActive(true);
                break;
            default:
                break;
        }
    }
}
