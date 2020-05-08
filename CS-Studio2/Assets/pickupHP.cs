using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupHP : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        SinglePlayerHP SP = collision.transform.GetComponent<SinglePlayerHP>();
        if (collision.transform.tag == "Player")
        {
            SP.currentHp += 5f;
            Destroy(this.gameObject);

        }
    }
}
