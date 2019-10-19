using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class LoginRequest : BaseRequest
{
    private LoginPanel loginPanel;
    
    // Start is called before the first frame update
    public override void Awake()
    {
        
        request = Request.User;
        actionCode = ActionCode.Login;
        
        loginPanel = GetComponent<LoginPanel>();
        
        base.Awake();
    }
    public void SendRequest(string username, string password) {
        string data = username + "," + password;
        base.SendRequest(data);

    }
    public override void OnResponse(string data) { 
    
        ReturnCode returnCode = (ReturnCode)int.Parse(data[0].ToString());
        loginPanel.OnLoginResponse(returnCode);
        //登入成功把信息把玩家信息设置到Player中
        if (returnCode == ReturnCode.Success) {
            string username = data[1].ToString();
            int totalCount = int.Parse(data[2].ToString());
            int winCount = int.Parse(data[3].ToString());
            UserData ud = new UserData(username, totalCount, winCount);
            facade.SetUserData(ud);
        }
        
       
    }
}
