using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using DG.Tweening;

public class RoomListPanel : BasePanel

{
    private RectTransform matchData;
    private RectTransform roomList;
    private VerticalLayoutGroup roomLayout;
    private GameObject roomItemPrefab;
    private CreateRoomRequest crRequest;
    private ListRoomRequest listRoomRequest;
    private JoinRoomRequest joinRoomRequest;
    private List<UserData> udList = null;

    private UserData ud1 = null;
    private UserData ud2 = null;

    private void Start()
    {
        matchData = transform.Find("MatchData").GetComponent<RectTransform>();
        roomList = transform.Find("RoomList").GetComponent<RectTransform>();
        roomLayout = transform.Find("RoomList/ScrollRect/Layout").GetComponent<VerticalLayoutGroup>();
        roomItemPrefab = Resources.Load("UIPanel/RoomItem") as GameObject;
        transform.Find("RoomList/Close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
        transform.Find("RoomList/Create").GetComponent<Button>().onClick.AddListener(OnCreateClick);
        transform.Find("RoomList/Fresh").GetComponent<Button>().onClick.AddListener(OnFreshClick);
        joinRoomRequest = GetComponent<JoinRoomRequest>();
        listRoomRequest = GetComponent<ListRoomRequest>();
        crRequest = GetComponent<CreateRoomRequest>();

    }

    private void OnCreateClick()
    {
       BasePanel panel= uiMng.PushPanel(UIPanelType.Room);
       crRequest.SetPanel(panel);
       crRequest.SendRequest();
        
    }
    private void OnFreshClick() {
        listRoomRequest.SendRequest();
    }

    public override void OnEnter()
    {
        
        SetBattleRes();
        if(matchData != null)
            PlayAnim();
        if (listRoomRequest == null)
            listRoomRequest = GetComponent<ListRoomRequest>();
        listRoomRequest.SendRequest();
    }
    public override void OnExit()
    {
        HideAnim();
    }
    public override void OnPause()
    {
        HideAnim();
    }
    public override void OnResume()
    {
        PlayAnim();
        listRoomRequest.SendRequest();
    }
    private void Update()
    {
        if (udList != null) {
            LoadRoomItem(udList);
            udList = null;
        }
        if (ud1 != null && ud2 != null) {
            BasePanel panel = uiMng.PushPanel(UIPanelType.Room);
            (panel as RoomPanel).SetAllPlayerResSync(ud1, ud2);
            ud1 = null;
            ud2 = null;
        }
    }
    private void OnCloseClick() {

        PlayClickSound();
        uiMng.PopPanel();
        
    }
    private void SetBattleRes() {
        UserData ud = facade.GetUserData();
        transform.Find("MatchData/UserName").GetComponent<Text>().text = ud.Username;
        transform.Find("MatchData/MatchTotalCount").GetComponent<Text>().text ="TotalMatch"+ ud.TotalCount.ToString(); ;
        transform.Find("MatchData/MatchWinCount").GetComponent<Text>().text ="WinMatch" + ud.WinCount.ToString();
    }
    public void LoadRoomItemSync(List<UserData> udList) {
        this.udList = udList;

    }
    //加载房间信息
    private void LoadRoomItem(List<UserData> udList) {
        RoomItem[] riArray= roomLayout.GetComponentsInChildren<RoomItem>();
        foreach (RoomItem ri in riArray) {
            ri.DestroySelf();
        }

        int count = udList.Count;
        for (int i = 0; i < count; i++) {
            GameObject roomItem = GameObject.Instantiate(roomItemPrefab);
            roomItem.transform.SetParent(roomLayout.transform);
            UserData ud = udList[i];
            roomItem.GetComponent<RoomItem>().SetRoomInfo(ud.Id,ud.Username, ud.TotalCount, ud.WinCount,this);
        }
        //解决房间过多而显示不出来
        int roomCount = GetComponentsInChildren<RoomItem>().Length;
        Vector2 size =roomLayout.GetComponent<RectTransform>().sizeDelta;
        roomLayout.GetComponent<RectTransform>().sizeDelta =
        new Vector2(size.x, roomCount * (roomItemPrefab.GetComponent<RectTransform>().sizeDelta.y + roomLayout.spacing));
    }
    public void OnJoinClick(int id) {
        joinRoomRequest.SendRequest(id);
    }
    public void OnJoinResponse(ReturnCode returnCode, UserData ud1, UserData ud2) {
        switch (returnCode) {
            case ReturnCode.NotFound:
                uiMng.ShowMessageSync("The room is gone then cannot join it");
                break;
            case ReturnCode.Fail:
                uiMng.ShowMessageSync("Cannot join the room due to maximent player");
                break;
            case ReturnCode.Success:
                this.ud1 = ud1;
                this.ud2 = ud2;
                break;
        }
    }
    private void PlayAnim() {
        gameObject.SetActive(true);

        matchData.localPosition = new Vector3(-1000, 0);
        matchData.DOLocalMoveX(-290, 0.5f);

        roomList.localPosition = new Vector3(1000, 0);
        roomList.DOLocalMoveX(171, 0.5f);
    }
    private void HideAnim() {
        matchData.DOLocalMoveX(-1000, 0.5f);

        roomList.DOLocalMoveX(1000, 0.5f).OnComplete(() => gameObject.SetActive(false));

    }
    
 }

