using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RoleData 
{
    public RoleType RoleType { get; private set;}
    public GameObject RolePrefab { get; private set; }
    public GameObject BulletPrefab { get; private set; }
    public RoleData(RoleType roleType, string rolePath, string bulletPath) {
        this.RoleType = roleType;
        this.RolePrefab = Resources.Load(rolePath) as GameObject;
        this.BulletPrefab = Resources.Load(bulletPath) as GameObject;
    }

}
