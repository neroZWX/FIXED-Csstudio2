using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image HpBar;
    public float EnemyHp = 100f;
    private float currentHp;
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
        obj.sharedMaterial.SetColor(name: "Main Color", value: Color.red);
 
    }
    void EnemyDead()
    {
        Destroy(gameObject);
    
    }
}
