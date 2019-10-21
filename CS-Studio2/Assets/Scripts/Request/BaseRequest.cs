using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class BaseRequest : MonoBehaviour
{
    protected Request request = Request.None;
    protected ActionCode actionCode = ActionCode.None;
    

    protected GameFacade _facade;

    protected GameFacade facade
    {
        get
        {
            if (_facade == null)
                _facade = GameFacade.Instance;
            return _facade;
        }
    }

    // Start is called before the first frame update
    public virtual  void Awake()
    {
        facade.AddRequest(actionCode, this);
        
        
        
    }
    protected void SendRequest(string data) {
        Debug.Log("SendRequest: " + actionCode.ToString());
        facade.SendRequest(request, actionCode, data);
    }
    public virtual void SendRequest() { }
    public virtual void OnResponse(string data) { }

    public virtual void OnDestroy() {
        if (facade != null)
            facade.RemoveRequest(actionCode);
    }
}
