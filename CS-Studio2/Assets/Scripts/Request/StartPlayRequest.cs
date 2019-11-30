using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class StartPlayRequest : BaseRequest
{
    private bool isAddControlScript = false;

    public override void Awake()
    {
        
        actionCode = ActionCode.StartPlay;
        base.Awake();
    }
    private void Update()
    {
        if (isAddControlScript) {
            facade.AddControlScript();
            isAddControlScript = false;
        }
      
    }
    public override void OnResponse(string data)
    {
        isAddControlScript = true;
    }
}
