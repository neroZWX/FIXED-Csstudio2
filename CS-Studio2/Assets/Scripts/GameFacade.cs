using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class GameFacade : MonoBehaviour
{
    private static GameFacade _instance;
    public static GameFacade Instance { get { return _instance; } }

    private UIManager uiMng;
    private Player player;
    private AudioManager audio;
    private CameraManager camera;
    private ClientManager clinetMng;
    private RequestManager requestMng;
    private void Awake()
    {
        if (_instance != null) {
            Destroy(this.gameObject); return;
        }
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitManager();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateManager();
    }
    private void InitManager()
    {
        uiMng = new UIManager(this);
        audio = new AudioManager(this);
        player = new Player(this);
        camera = new CameraManager(this);
        clinetMng = new ClientManager(this);
        requestMng = new RequestManager(this);

        uiMng.OnInit();
        audio.OnInit();
        player.OnInit();
        camera.OnInit();
        clinetMng.OnInit();
        requestMng.OnInit();

    }
    private void DestroyManager()
    {
        uiMng.OnDestroy();
        audio.OnDestroy();
        player.OnDestroy();
        camera.OnDestroy();
        clinetMng.OnDestroy();
        requestMng.OnDestroy();
    }
    private void OnDestroy()
    {
        DestroyManager();
    }
    public void UpdateManager() {
        uiMng.Update();
        audio.Update();
        player.Update();
        camera.Update();
        clinetMng.Update();
        requestMng.Update();
    }



    public void AddRequest(ActionCode actionCode, BaseRequest baserequest) {
        requestMng.AddRequest(actionCode, baserequest);
    }
    public void RemoveRequest(ActionCode actionCode) {
        requestMng.RemoveRequest(actionCode);
    }
    public void HandleReponse(ActionCode actionCode, string data) {
        requestMng.HandleReponse(actionCode, data);
    }
    public void ShowMessage(string msg) {
        uiMng.ShowMessage(msg);
    }
    public void SendRequest(Request request, ActionCode actionCode, string data)
    {
        clinetMng.SendRequest(request, actionCode, data);
    }
    public void PlaySoundBGUI(string soundName) {
        audio.PlaySoundBGUI(soundName);
    }
    //AudioSource audioSource;
    public void PlayNormalSound(string soundName) {

        audio.PlayNormalSound(soundName);
    }
    public void SetUserData(UserData ud) {
        player.UserData = ud;
    }
    public UserData GetUserData (){
        return player.UserData;
}
}
