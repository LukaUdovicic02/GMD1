using System.Collections;
using Game;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour, IShoot
{
    public int currentBulletCount = 30;
    public int maxBulletCount = 30;

    public TextMeshProUGUI currentAmmo;
    public TextMeshProUGUI maxAmmo;

    public bool isReloading;
    private float reloadTimer;

    public GameObject muzzleFlashAnimation;
    private bool isShooting;
    private float shootingTimer = 0.2f;


    void Update()
    {
        SetBulletAmount();

        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                currentBulletCount = maxBulletCount;
                isReloading = false;
            }
        }

        if (isShooting)
        {
            muzzleFlashAnimation.SetActive(true);
            shootingTimer -= Time.deltaTime;
            if (shootingTimer <= 0.1)
            {
                muzzleFlashAnimation.SetActive(false);
                isShooting = false;
                shootingTimer = 0.2f;
            }
        }
    }

    public void Shoot()
    {   
        if (currentBulletCount > 0 && !isReloading)
        {
            isShooting = true;
            currentBulletCount--;
            if (currentBulletCount == 0)
            {
                StartReload();
            }
        }
    }

    public void StartReload()
    {
        isReloading = true;
        reloadTimer = 2.5f;
    }

    public void SetBulletAmount()
    {
        currentAmmo.text = currentBulletCount.ToString();
        maxAmmo.text = maxBulletCount.ToString();
    }
}