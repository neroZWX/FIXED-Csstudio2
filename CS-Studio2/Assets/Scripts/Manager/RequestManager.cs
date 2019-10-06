using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager
{
     
    public RequestManager(GameFacade gameFacade) : base(gameFacade) {
       
    }


    // save request code 
    private Dictionary<ActionCode, BaseRequest> requestDict = new Dictionary<ActionCode, BaseRequest>();

    public void AddRequest(ActionCode actionCode, BaseRequest baserequest) {
        requestDict.Add( actionCode, baserequest);
    }
    // remove request code
    public void RemoveRequest(ActionCode actionCode) {
        requestDict.Remove(actionCode);
    }

    // reponse the server
    public void HandleReponse(ActionCode actionCode,string data) {
        BaseRequest baserequest = requestDict.TryGet<ActionCode, BaseRequest>(actionCode);
        if (baserequest == null) {
            Debug.LogWarning("Cannot get request code" + actionCode);
            return;
        }
        baserequest.OnResponse(data);
    }
}
