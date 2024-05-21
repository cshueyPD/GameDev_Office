using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileAmmoDisplay : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float horizontalSpacing = 50f;
    [SerializeField] private float verticalPosition = -50f;
    [SerializeField] private int count = 4;
    [SerializeField] private int remaining = 0;
    [SerializeField] private float reloadInterval = .25f;
    [SerializeField] private bool canFire = true;
    [SerializeField] private bool canReload = true;
    private List<GameObject> projectiles = new();
    
    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject projectileObject = Instantiate(projectilePrefab, transform);
            projectileObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((i+1) * horizontalSpacing, verticalPosition);
            projectiles.Add(projectileObject);
        }
        remaining = count;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && canFire)
        {
            UseAmmo();
        }
        CheckReloadAmmo();
    }

    public void UseAmmo()
    {
        remaining--;
        if (remaining < 0)
        {
            remaining = 0;
            canFire = false;
            gameManager.Instance.canFire = canFire;
        }
        foreach (Transform child in projectiles[remaining].transform)
        {
            if (child.gameObject.name == "Projectile")
            {
                child.gameObject.SetActive(false); 
            }
        }
        
    }

    public void CheckReloadAmmo()
    {
        if (remaining == 0 && canReload)
        {
            StartCoroutine(ReloadAmmo());  
        }
    }

    private IEnumerator ReloadAmmo()
    {
        yield return new WaitForSeconds(reloadInterval);
        foreach (var projectile in projectiles)
        {
            foreach (Transform child in projectile.transform)
            {
                if (child.gameObject.name == "Projectile")
                {
                    child.gameObject.SetActive(true);
                }
            }
            yield return new WaitForSeconds(reloadInterval);
        }
        remaining = count;
        canFire = true;
        gameManager.Instance.canFire = canFire;
    }
}