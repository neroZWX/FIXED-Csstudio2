using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupHP : MonoBehaviour
{
    public AudioClip PickUpSound;

    void OnCollisionEnter(Collision collision)
    {
        SinglePlayerHP SP = collision.transform.GetComponent<SinglePlayerHP>();
        if (collision.transform.tag == "Player")
        {
            PlayPickUpSound();
            
            
            SP.currentHp += 5f;

            Destroy(this.gameObject);
            
        }
    }
    public void PlayPickUpSound() {
        GameObject obj = GameObject.Find("AudioHolder");
        AudioSource source = obj.GetComponent<AudioSource>();
        int soundVolume = Random.Range(1, 2);
        source.PlayOneShot(PickUpSound, soundVolume);
        print("Now Sound voulem is " + soundVolume);
    }
}
