using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager 
{
    protected GameFacade gamefacde;
    public BaseManager(GameFacade gamefacde) {
        this.gamefacde = gamefacde;
    }
    public virtual void OnInit() { }
    public virtual void OnDestroy() { }
}
