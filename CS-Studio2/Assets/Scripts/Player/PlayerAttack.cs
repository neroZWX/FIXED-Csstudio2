using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public GameObject AkBulletPrefab;
    private Transform AKTrans;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AKTrans = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/" +
            "Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/WeaponContainer/weapon_fal");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded")) {

            if (Input.GetMouseButton(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool IsCollider = Physics.Raycast(ray, out hit);
                if (IsCollider) {
                    Vector3 point = hit.point;
                    anim.SetTrigger("Attack");  
                    Shoot(point);
                }
            }
        }
    }
    private void Shoot(Vector3 targetPoint) {
        targetPoint.y = transform.position.y;
        Vector3 dir = targetPoint - transform.position;
        GameObject.Instantiate(AkBulletPrefab, AKTrans.position, Quaternion.LookRotation(dir));

    }
}
