using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : BasePanel
{
    private Button loginButton;
    public override void OnEnter()
    {
        base.OnEnter();
        Button loginButton = transform.Find("LoginButton").GetComponent<Button>();
        loginButton.onClick.AddListener(OnLoginClick);

    }
    private void OnLoginClick() {
        uiMng.PushPanel(UIPanelType.Login);
        

    }
   //public override void OnPause()
   // {
   //     base.OnPause();
        
   //     loginButton.gameObject.SetActive(false);
        
   //}
   public override void OnResume()
    {
        base.OnResume();
        loginButton.gameObject.SetActive(true);
        loginButton.transform.DOScale(1, 0.5f);
    }

}
