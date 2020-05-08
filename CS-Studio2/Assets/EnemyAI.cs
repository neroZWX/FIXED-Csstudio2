using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    Animator an;
    private Rigidbody rg;
    public float EnemyWalkersDamage = 10f;
    void Start()
    {
        an = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance < 10f && distance > 3f)
        {
            
            an.SetBool("CanSeeCh", true);
            gameObject.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
        }
        else if (distance <= 3f)
        {
            rg.constraints = RigidbodyConstraints.FreezePosition;
            an.SetBool("CanSeeCh", false);
            an.SetTrigger("Attack");
            
            

        }
        else
        {
            an.SetBool("CanSeeCh", false);
      
        }
        
        
    }
      void OnCollisionEnter(Collision collision)
        {
            SinglePlayerHP SplayerHP = collision.transform.GetComponent<SinglePlayerHP>();
            if (collision.transform.tag == "Player")
            {
                SplayerHP.Takedmage(EnemyWalkersDamage);

            }
        }
}
