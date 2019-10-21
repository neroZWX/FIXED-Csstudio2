using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListPanel : BasePanel

{
    private RectTransform matchData;
    private RectTransform roomList;
    private VerticalLayoutGroup roomLayout;
    private GameObject roomItemPrefab;
    private CreateRoomRequest crRequest;
    private ListRoomRequest listRoomRequest;

    private List<UserData> udList = null;

    private void Start()
    {
        matchData = transform.Find("MatchData").GetComponent<RectTransform>();
        roomList = transform.Find("RoomList").GetComponent<RectTransform>();
        roomLayout = transform.Find("RoomList/ScrollRect/Layout").GetComponent<VerticalLayoutGroup>();
        roomItemPrefab = Resources.Load("UIPanel/RoomList") as GameObject;
        transform.Find("RoomList/Close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
        transform.Find("RoomList/Create").GetComponent<Button>().onClick.AddListener(OnCreateClick);
        listRoomRequest = GetComponent<ListRoomRequest>();
        crRequest = GetComponent<CreateRoomRequest>();

    }

    private void OnCreateClick()
    {
        uiMng.PushPanel(UIPanelType.Room);
        //if (crRequest == null)
        //{
        //    crRequest = GetComponent<CreateRoomRequest>();
        //    crRequest.SendRequest();
        //}
        
    }

    public override void OnEnter()
    {
        gameObject.SetActive(true);
        SetBattleRes();
        if (listRoomRequest == null)
            listRoomRequest = GetComponent<ListRoomRequest>();
        listRoomRequest.SendRequest();
    }
    public override void OnExit()
    {
       
    }
    public override void OnPause()
    {
        
    }
    public override void OnResume()
    {
        listRoomRequest.SendRequest();
    }
    private void Update()
    {
        if (udList != null) {
            LoadRoomItem(udList);
            udList = null;
        }
    }
    private void OnCloseClick() {

        PlayClickSound();
        uiMng.PopPanel();
        gameObject.SetActive(false);
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
            roomItem.GetComponent<RoomItem>().SetRoomInfo(ud.Username, ud.TotalCount, ud.WinCount);
        }
        //解决房间过多而显示不出来
        int roomCount = GetComponentsInChildren<RoomItem>().Length;
        Vector2 size =roomLayout.GetComponent<RectTransform>().sizeDelta;
        roomLayout.GetComponent<RectTransform>().sizeDelta =
        new Vector2(size.x, roomCount * (roomItemPrefab.GetComponent<RectTransform>().sizeDelta.y+roomLayout.spacing));
    }
    
    }

