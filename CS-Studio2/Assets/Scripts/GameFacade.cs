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
    private ClientManager clinet;
    private RequestManager requestMng;
    private void Awake()
    {
        if (_instance != null) {
            Destroy(this.gameObject);return;
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
        
    }
    private void InitManager()
    {
        uiMng= new UIManager(this);
        audio = new AudioManager(this);
        player = new Player(this);
        camera = new CameraManager(this);
        clinet = new ClientManager(this);
        requestMng = new RequestManager(this);

        uiMng.OnInit();
        audio.OnInit();
        player.OnInit();
        camera.OnInit();
        clinet.OnInit();
        requestMng.OnInit();

    }
    private void DestroyManager()
    {
        uiMng.OnDestroy();
        audio.OnDestroy();
        player.OnDestroy();
        camera.OnDestroy();
        clinet.OnDestroy();
        requestMng.OnDestroy();
    }
    private void OnDestroy()
    {
        DestroyManager();
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
}
