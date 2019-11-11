using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Player : BaseManager
{
    private UserData userData;
    private Dictionary<RoleType, RoleData> roleDataDict = new Dictionary<RoleType, RoleData>();

    public Player(GameFacade gameFacade) : base(gameFacade) { }
    public UserData UserData {
        set { userData = value; }
        get { return userData; }
    }
    private void InitRoleDataDict() {
        roleDataDict.Add(RoleType.role1, new RoleData(RoleType.role1, "AKBullets", "TS_militias_jungle_A"));
    }
}
