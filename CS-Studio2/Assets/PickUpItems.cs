using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public AudioClip PickUpSound;
    //private pickupHP ph;
    
    void Start()
    {
        // ph = GetComponent<pickupHP>();
    }
    void OnCollisionEnter(Collision collision)
    {
        SingleShooting SS = collision.transform.GetComponent<SingleShooting>();
        if (collision.transform.tag == "Player")
        {
            PlayPickUpSound();
            SS.PistolBulletNum += 10;
            SS.PistolBulletNumText.text = "" + SS.PistolBulletNum;
            Destroy(this.gameObject);
            
           

        }

    }
    public void PlayPickUpSound()
    {
        GameObject obj = GameObject.Find("AudioHolder");
        AudioSource source = obj.GetComponent<AudioSource>();
        int soundVolume = Random.Range(1, 2);
        source.PlayOneShot(PickUpSound, soundVolume);
        print("Now Sound voulem is " + soundVolume);
    }
}
