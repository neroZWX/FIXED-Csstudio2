using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public GameObject AkBulletPrefab;
    private Transform AKTrans;
    private Vector3 shootDir;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AKTrans = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/" +
            "Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/WeaponContainer/FirePoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded")) {

            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool IsCollider = Physics.Raycast(ray, out hit);
                if (IsCollider) {
                    Vector3 targetPoint = hit.point;
                    targetPoint.y = transform.position.y;
                    shootDir  = targetPoint - transform.position;
                    transform.rotation = Quaternion.LookRotation(shootDir);
                    anim.SetTrigger("Attack");
                    Invoke("Shoot", 0.5f);
                    Shoot(shootDir);
                }
            }
        }
    }
    private void Shoot(Vector3 dir) {
        
        GameObject.Instantiate(AkBulletPrefab, AKTrans.position, Quaternion.LookRotation(shootDir));

    }
}
