﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;

public class RegisterRequest : BaseRequest
{
    private RegisterPanel registerPanel;
     
    public override void Awake()
    {
        request = Request.User;
        actionCode = ActionCode.Register;

        Debug.Log("registerreque: " + actionCode.ToString());
        //actionCode = ActionCode.Register;


        registerPanel = GetComponent<RegisterPanel>();
        base.Awake();
    }
    public void SendRequest(string username, string password)
    {
        string data = username + "," + password;
        base.SendRequest(data);

    }
    public override void OnResponse(string data)
    {
        ReturnCode returnCode = (ReturnCode)int.Parse(data);
        registerPanel.OnRegisterResponse(returnCode);
        print("1");
    }
}

