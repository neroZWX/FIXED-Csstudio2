using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RoleData 
{
    private const string Prefix_Prefab = "Prefabs/";
    public RoleType RoleType { get; private set;}
    public GameObject RolePrefab { get; private set; }
    public GameObject BulletPrefab { get; private set; }
    public Vector3 SpawnPosition { get; private set; }
  
    public RoleData(RoleType roleType, string rolePath, string bulletPath,Transform spawnPos) {
        this.RoleType = roleType;
        this.RolePrefab = Resources.Load(Prefix_Prefab + rolePath) as GameObject;
        this.BulletPrefab = Resources.Load(bulletPath) as GameObject;
        this.SpawnPosition = spawnPos.position;
    }

}
