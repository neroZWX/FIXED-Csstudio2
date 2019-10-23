using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class CreateRoomRequest : BaseRequest
{
    private RoomPanel roomPanel;
    public override void Awake()
    {
        request = Request.Room;
        actionCode = ActionCode.CreateRoom;
        
        base.Awake();
    }
    public void SetPanel(BasePanel panel) {
        roomPanel = panel as RoomPanel;
    }

    public override void SendRequest()
    {
        base.SendRequest("nu");
    }
    public override void OnResponse(string data)
    {
        string[] strs = data.Split(',');
        ReturnCode returnCode = (ReturnCode)int.Parse(data);
        if (returnCode == ReturnCode.Success)
        {

            roomPanel.SetLocalPlayerResSync();

        }
    }
}
