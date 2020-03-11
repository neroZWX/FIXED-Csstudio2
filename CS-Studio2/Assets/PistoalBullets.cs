using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistoalBullets : MonoBehaviour
{    
    public float PistolDamage =10f;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider Hit)
    {
        EnemyHP enhp = Hit.transform.GetComponent<EnemyHP>();
        if (Hit.transform.tag == "Enemy")
        {
            enhp.TakeDamage(PistolDamage);

        }
    }
}
