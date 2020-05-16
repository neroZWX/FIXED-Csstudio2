using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerHP : MonoBehaviour
{
    public Image HPBAR;
    public float MaxHp =  100f;
    public float currentHp;
    public GameObject gameoverui;
    public GameObject maincharacter;


    void Start()
    {
        currentHp = MaxHp;
        gameoverui = GameObject.Find("GameOver");
        gameoverui.SetActive(false);
        maincharacter = GameObject.Find("SinglePlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0) {
            gameoverui.SetActive(true);
            Destroy(maincharacter, 2f);
        }
        HPBAR.fillAmount = currentHp / MaxHp;
    }
    public void Takedmage(float takedamage) {
           currentHp -= takedamage;
    }
}
