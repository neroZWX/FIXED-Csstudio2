using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerHP : MonoBehaviour
{
    public Image HPBAR;
    public float MaxHp =  100f;
    public float currentHp; 


    void Start()
    {
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0) { 
        
        }
        HPBAR.fillAmount = currentHp / MaxHp;
    }
    public void Takedmage(float takedamage) {
           currentHp -= takedamage;
    }
}
