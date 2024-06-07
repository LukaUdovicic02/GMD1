using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public string shootAxisName;
    public Ammo ammo;
    public float fireRate = 0.5f; 

    private bool isShooting;
    private float nextFireTime = 0f;

    void Start()
    {
        ammo = GameObject.FindWithTag("ammo").GetComponent<Ammo>();
        isShooting = false;

       
    }

    void Update()
    {
        if (CompareTag("Player 1"))
        {
            shootAxisName = "FireWeapon";
        }
        else if (CompareTag("Player 2"))
        {   
            shootAxisName = "FireWeapon2";
        }
        
        if (ammo.currentBulletCount > 0)
        {
            float axisValue = Input.GetAxis(shootAxisName);

            Debug.Log($"{gameObject.name} Axis {shootAxisName} value: {axisValue}");

            if (axisValue > 0f && !isShooting && Time.time >= nextFireTime)
            {
                Debug.Log($"{gameObject.name} Shot fired");
                Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
                ammo.Shoot();
                isShooting = true;
                nextFireTime = Time.time + fireRate;
            }
            else if (axisValue == 0f)
            {
                isShooting = false;
            }
        }
    }
}