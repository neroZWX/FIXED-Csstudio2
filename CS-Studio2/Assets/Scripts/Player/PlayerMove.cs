using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 3;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v)* speed * Time.deltaTime,Space.World);
        transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));
        //controllering the animation of the character
        float res = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
        anim.SetFloat("Forward",res);
    }
}
