using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image HpBar;
    public float EnemyHp = 100f;
    public int numDropItemMin = 1;
    public int numDropItemMax = 3;
    public GameObject pickupBullets;
    public GameObject pickupHP;
    private float currentHp;
 
   // public float EnemyWalkersDamage = 10f;
    public SkinnedMeshRenderer obj;
  

    private void Start()
    {
       
        currentHp = EnemyHp;
        obj = GetComponent<SkinnedMeshRenderer>();
       
    }
    private void Update()
    {
        
        if (currentHp <= 0)
        {
            EnemyDead();
        }
        HpBar.fillAmount = currentHp / EnemyHp;
    }
    public void TakeDamage(float takeDamage) {
        currentHp -= takeDamage;
      //  obj.sharedMaterial.SetColor(name: "Main Color", value: Color.red);
 
    }
    void EnemyDead()
    {
        Destroy(gameObject);
        Vector3 DropItemLocation = transform.position;
        int DropItems = Random.Range(numDropItemMin, numDropItemMax);
        for (int i = 0; i < DropItems; i++) {
            Vector3 randomItemLocation = DropItemLocation;
            randomItemLocation += new Vector3(Random.Range(-2, 2), 0.2f, Random.Range(-2, 2));
            if (Random.value > 0.5f)
                Instantiate(pickupBullets, randomItemLocation, pickupBullets.transform.rotation);
            else
                Instantiate(pickupHP, randomItemLocation, pickupHP.transform.rotation);

        }
        
    }
 
}
