using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Bullets : MonoBehaviour
{
    public RoleType roleType;
    public int speed = 50;  
    private Rigidbody rgd;
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        
    }

   void FixedUpdate()
    {
        rgd.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        
        Destroy(gameObject, 5f);
    }
   
}
