using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseManager
{
    private UserData userData;

    public Player(GameFacade gameFacade) : base(gameFacade) { }
    public UserData UserData {
        set { userData = value; }
        get { return userData; }
    }

}
