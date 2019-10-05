using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class BaseRequest : MonoBehaviour
{
    private Request request = Request.None;
    // Start is called before the first frame update
    public virtual  void Awake()
    {
        GameFacade.Instance.AddRequest(request, this);
        
    }
    public virtual void SendRequest() { }
    public virtual void OnResponse(string data) { }

    public virtual void OnDestroy() {
        GameFacade.Instance.RemoveRequest(request);
    }
}
