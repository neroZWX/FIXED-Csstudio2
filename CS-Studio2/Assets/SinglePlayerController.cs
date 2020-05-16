using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerController : MonoBehaviour
{
    public float forward = 0;
    

    private float speed = 6;
    private Animator anim;
    Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded") == false) return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime, Space.World);

            transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));

            //controllering the animation of the character
            float res = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
            forward = res;
            anim.SetFloat("Forward", res);
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
        //Camera.main.screen
        //print(mousePos);
        //mousePos.Normalize();

    }
    void LateUpdate()
    {

        //Vector3 LookDir = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));

        // print("lookdir: " + LookDir);
        //print("screen2worl: " + Input.mousePosition);// Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //float rotationY = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, rotationY + 90f, 0);

        Vector3 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        //print(dir);
        float rot = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        //print(rot);
        transform.rotation = Quaternion.Euler(0f, rot + 180f, 0f);
        //print(transform.rotation);


        //Debug.Log(rotationY);
        //Debug.Log(Quaternion.Euler(0, rotationY + 90f, 0));
    }

   
}
