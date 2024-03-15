using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public KeyCode et;

    public string PlayerTag;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(et))
        {
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        }
    }
    
    
}