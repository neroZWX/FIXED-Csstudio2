using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleShooting : MonoBehaviour
{
  
    public Transform firePoint;
    public GameObject PistoalPrefab;
    public float PistolSpeed = 50f;
    public int PistolBulletNum = 50;
    public Text PistolBulletNumText;

     void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    // Update is called once per frame

    public void Shoot()
    {
        if (PistolBulletNum > 0)
        {
            GameObject PistoalPre = Instantiate(PistoalPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = PistoalPre.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.right * PistolSpeed * 1.5f, ForceMode.Impulse);
            PistolBulletNum = PistolBulletNum - 1;
            PistolBulletNumText.text = " " + PistolBulletNum;
        }
        
        
      

    }
}


