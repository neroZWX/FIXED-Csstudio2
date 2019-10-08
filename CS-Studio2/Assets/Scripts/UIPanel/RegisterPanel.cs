using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Common;

public class RegisterPanel : BasePanel
{
    private InputField usernameIF;
    private InputField passwordIF;
    private InputField rePasswordIF;
    private RegisterRequest registerRequest;

    public void Start()
    {
        registerRequest = GetComponent<RegisterRequest>();
        usernameIF = transform.Find("UsernameLabel/UserNameInput").GetComponent<InputField>();
        passwordIF = transform.Find("PasswordLabel/passwordInput").GetComponent<InputField>();
        rePasswordIF = transform.Find("ConfirmPasswordLabel/ConfirmpasswordInput").GetComponent<InputField>();

        transform.Find("RegisterButton").GetComponent<Button>().onClick.AddListener(OnRegisterClick);
        transform.Find("Close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
    }
    public override void OnEnter()
    {
        gameObject.SetActive(true);

        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
        transform.localPosition = new Vector3(0, 1000, 0);
        transform.DOLocalMove(Vector3.zero, 0.5f);
    }
    public void OnRegisterClick()
    {
        string msg = "";
        if (string.IsNullOrEmpty(usernameIF.text)) {
            msg += "please enter your username!";
        }
        if (string.IsNullOrEmpty(passwordIF.text))
        {
            msg += "\nplease enter your Password!";
        }
        if (passwordIF.text != rePasswordIF.text)
        {
            msg += "\nplease confirm your password!";
        }
        if (msg != "") {
            uiMng.ShowMessage(msg); return;
            print(1);
        }
        // TODO register a account and send it to server
        registerRequest.SendRequest(usernameIF.text, passwordIF.text);
    }
    public void OnRegisterResponse(ReturnCode returnCode)
    {
        if (returnCode == ReturnCode.Success)
        {
            uiMng.ShowMessageSync("Register success!");
        }
        else {
            uiMng.ShowMessageSync("User name has existed!Try it again");
        }
    }
    public void OnCloseClick() {
        transform.DOScale(0, 0.5f);
        Tweener tweener = transform.DOLocalMove(new Vector3(0, 1000, 0), 0.5f);
        tweener.OnComplete(() => uiMng.PopPanel());
    }
    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}
