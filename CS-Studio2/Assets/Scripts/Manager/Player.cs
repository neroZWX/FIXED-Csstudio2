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
    private GameObject playerSyncRequest;
    private GameObject remoteRoleGameobject;
    private ShootRequest shootReuqest;

    public void SetCurrentRoleType(RoleType rt)
    {
        currentRoleType = rt;

    }

    public Player(GameFacade gameFacade) : base(gameFacade) { }
    public UserData UserData
    {
        set { userData = value; }
        get { return userData; }
    }
    public override void OnInit()
    {
        playerPositions = GameObject.Find("playerPosition").transform;
        InitRoleDataDict();
    }
    private void InitRoleDataDict()
    {
        roleDataDict.Add(RoleType.role1, new RoleData(RoleType.role1, "TS_militias_jungle_A", "AKBullets", playerPositions.Find("position1")));
        roleDataDict.Add(RoleType.role2, new RoleData(RoleType.role2, "TS_militias_jungle_D", "AKBullets1", playerPositions.Find("position2")));
    }
    public void SpawnRoles()
    {
        foreach (RoleData rd in roleDataDict.Values)
        {

            GameObject go = GameObject.Instantiate(rd.RolePrefab, rd.SpawnPosition, Quaternion.identity);
            if (rd.RoleType == currentRoleType)
            {
                currentRoleGameObject = go;

            }
            else {
                remoteRoleGameobject = go;
            }
        }
    }
    public GameObject GetCurrentRoleGameObject()
    {
        return currentRoleGameObject;
    }
    private RoleData GetRoleData(RoleType rt) {
        RoleData rd = null;
        roleDataDict.TryGetValue(rt, out rd);
        return rd;
    }

    public void AddControlScript()
    {
        currentRoleGameObject.AddComponent<PlayerMove>();
        PlayerAttack playerattack = currentRoleGameObject.AddComponent<PlayerAttack>();
        RoleType rt = currentRoleGameObject.GetComponent<PlayerInfo>().roleType;
        RoleData rd = GetRoleData(rt);
        playerattack.AkBulletPrefab = rd.BulletPrefab;
        playerattack.SetPlayerMng(this);
     }
    public void CreateSyncRequest() {
        playerSyncRequest = new GameObject("PlayerSyncRequest");
        playerSyncRequest.AddComponent<MoveRequest>().SetLocalPlayer(currentRoleGameObject.transform, currentRoleGameObject.GetComponent<PlayerMove>())
            .SetRemotePlayer(remoteRoleGameobject.transform);
        shootReuqest = playerSyncRequest.AddComponent<ShootRequest>();
        shootReuqest.playerMng = this;
    }
    public void Shoot(GameObject AkBulletPrefab, Vector3 pos, Quaternion rotation) {
        GameObject.Instantiate(AkBulletPrefab, pos, rotation);
        shootReuqest.SendRequest(AkBulletPrefab.GetComponent<Bullets>().roleType, pos, rotation.eulerAngles);
    }
    public void RemoteShoot(RoleType rt, Vector3 pos, Vector3 rotation) {

        GameObject AKBulletPrefab = GetRoleData(rt).BulletPrefab;
        Transform transform = GameObject.Instantiate(AKBulletPrefab).GetComponent<Transform>();
        transform.position = pos;
        transform.eulerAngles = rotation;
    }
}
