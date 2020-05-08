using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        SingleShooting SS = collision.transform.GetComponent<SingleShooting>();
        if (collision.transform.tag == "Player")
        {
            SS.PistolBulletNum += 5;
            SS.PistolBulletNumText.text = "" + SS.PistolBulletNum;
            Destroy(this.gameObject);

        }
    }
}
