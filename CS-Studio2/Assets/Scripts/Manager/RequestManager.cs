using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager
{
     
    public RequestManager(GameFacade gameFacade) : base(gameFacade) {
       
    }


    // save request code 
    private Dictionary<Request, BaseRequest> requestDict = new Dictionary<Request, BaseRequest>();

    public void AddRequest(Request request, BaseRequest baserequest) {
        requestDict.Add(request, baserequest);
    }
    // remove request code
    public void RemoveRequest(Request request) {
        requestDict.Remove(request);
    }

    // reponse the server
    public void HandleReponse(Request request,string data) {
        BaseRequest baserequest = requestDict.TryGet<Request,BaseRequest>(request);
        if (baserequest == null) {
            Debug.LogWarning("Cannot get request code" + request);
            return;
        }
        baserequest.OnResponse(data);
    }
}
