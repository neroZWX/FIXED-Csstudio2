using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image HpBar;
    public float EnemyHp = 100f;
    private float currentHp;

    private void Start()
    {
        currentHp = EnemyHp;
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
 
    }
    void EnemyDead()
    {
        Destroy(gameObject);
    
    }
}
