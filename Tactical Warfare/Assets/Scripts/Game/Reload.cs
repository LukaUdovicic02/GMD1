using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public GameObject reloadAnim;
    private bool ajdex;
    public float timer = 2.5f;
    public Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo.isReloading)
        {
            reloadAnim.SetActive(true);
            ajdex = true;

            if (ajdex)
            {
                timer -= Time.deltaTime;
                if (timer <= 0.1)
                {
                    reloadAnim.SetActive(false);
                }
            }
        }
        else
        {
            timer = 2.5f;
        }
    }
}