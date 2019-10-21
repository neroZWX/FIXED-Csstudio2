using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Common;

public class LoginPanel : BasePanel
{
    private Button closeButton;
    private InputField usernameIF;
    private InputField passwordIF;
    private LoginRequest loginRequest;
    // public Button loginButton;
    //public Button registerButton;

    public void Start() {
        loginRequest = GetComponent<LoginRequest>();
        usernameIF = transform.Find("UsernameLabel/UserNameInput").GetComponent<InputField>();
        passwordIF = transform.Find("PasswordLabel/passwordInput").GetComponent<InputField>();
        closeButton = transform.Find("Close").GetComponent<Button>();
        closeButton.onClick.AddListener(OnCloseClick);
        transform.Find("LoginButton").GetComponent<Button>().onClick.AddListener(OnLoginClick);
        transform.Find("RegisterButton1").GetComponent<Button>().onClick.AddListener(OnRegisterClick);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        PlayAnmi();
    }
    public override void OnPause()
    {
        HideAnmi();

    }
    public override void OnResume()
    {
        PlayAnmi();
    }
    public override void OnExit()
    {
        HideAnmi();
    }
    private void OnCloseClick() {
        PlayClickSound();
        uiMng.PopPanel();
        
    }
    private void OnLoginClick() {
        PlayClickSound();
        string msg = "";
        if (string.IsNullOrEmpty(usernameIF.text)) {
            msg += "userName cannot be null";
            print("userName cannot be null");
        }
        if (string.IsNullOrEmpty(passwordIF.text))
        {
            msg += "password cannot be null";
            print("password cannot be null");
        }
        if (msg != "") {
            uiMng.ShowMessage(msg);return;
        }
        //todo Sending message to server for check it
        loginRequest.SendRequest(usernameIF.text, passwordIF.text);
    }
    public void OnLoginResponse(ReturnCode returnCode) {
        if (returnCode == ReturnCode.Success)
        {
            //TODO
            uiMng.PushPanelSync(UIPanelType.RoomList);
            
        }
        else {
            uiMng.ShowMessageSync("Username or password is invaild, please try it again!");
        }
    }
    private void OnRegisterClick()
    {
        PlayClickSound();
        uiMng.PushPanel(UIPanelType.Register);
    }
    private void PlayAnmi() {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
        transform.localPosition = new Vector3(0, 1000, 0);
        transform.DOLocalMove(Vector3.zero, 0.5f);
    }
    private void HideAnmi() {
        transform.DOScale(0, 0.5f);
        Tweener tweener = transform.DOLocalMove(new Vector3(0, 1000, 0), 0.5f);
        tweener.OnComplete(() => gameObject.SetActive(false));
    }
}