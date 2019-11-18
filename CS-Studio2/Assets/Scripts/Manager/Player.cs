using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Player : BaseManager
{
    private UserData userData;
    private Dictionary<RoleType, RoleData> roleDataDict = new Dictionary<RoleType, RoleData>();
    private Transform playerPositions;
    private RoleType currentRoleType;
    private GameObject currentRoleGameObject;

    public void SetCurrentRoleType(RoleType rt) {
        currentRoleType = rt; 

    }

    public Player(GameFacade gameFacade) : base(gameFacade) { }
    public UserData UserData {
        set { userData = value; }
        get { return userData; }
    }
    public override void OnInit()
    {
        playerPositions = GameObject.Find("playerPosition").transform;
        InitRoleDataDict();
    }
    private void InitRoleDataDict() {
        roleDataDict.Add(RoleType.role1, new RoleData(RoleType.role1, "AKBullets", "TS_militias_jungle_A",playerPositions.Find("position1")));
        roleDataDict.Add(RoleType.role2, new RoleData(RoleType.role2, "AKBullets", "TS_militias_jungle_A",playerPositions.Find("position2")));
    }
    public void SpawnRoles() {
        foreach (RoleData rd in roleDataDict.Values) {

           GameObject go= GameObject.Instantiate(rd.RolePrefab, rd.SpawnPosition, Quaternion.identity);
            if (rd.RoleType == currentRoleType) {
                currentRoleGameObject = go;

            }          
        }
    }
    public GameObject GetCurrentRoleGameObject() {
        return currentRoleGameObject;
    }
}
