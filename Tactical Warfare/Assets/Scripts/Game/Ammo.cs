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

    private bool isReloading = false;
    private float reloadTimer = 0f;

    private void Start()
    {
        if (currentBulletCount != 0)
        {
            Shooting.OnShoot += Shoot;
        }
    }

    private void OnDestroy()
    {
        Shooting.OnShoot -= Shoot;
    }

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
    }

    public void Shoot()
    {
        if (currentBulletCount > 0 && !isReloading)
        {
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