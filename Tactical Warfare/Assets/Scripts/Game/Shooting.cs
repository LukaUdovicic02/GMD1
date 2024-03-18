using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public KeyCode et;
    public Ammo ammo;

    public string PlayerTag;

    public delegate void ShootingAction();

    public static event ShootingAction OnShoot;


    // Start is called before the first frame update
    void Start()
    {
        ammo = GameObject.FindWithTag("ammo").GetComponent<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo.currentBulletCount > 0)
        {
            if (Input.GetKeyDown(et))
            {
                Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

                ammo.Shoot();
            }
        }
    }
}