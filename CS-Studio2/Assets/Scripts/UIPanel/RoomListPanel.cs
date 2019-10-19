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
    private void Start()
    {
        matchData = transform.Find("MatchData").GetComponent<RectTransform>();
        roomList = transform.Find("RoomList").GetComponent<RectTransform>();
        roomLayout = transform.Find("RoomList/ScrollRect/Layout").GetComponent<VerticalLayoutGroup>();
        roomItemPrefab = Resources.Load("UIPanel/RoomList") as GameObject;
        transform.Find("RoomList/Close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
       
    }
    public override void OnEnter()
    {
        gameObject.SetActive(true);
        SetBattleRes();

    }
    public override void OnExit()
    {
       
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
    private void LoadRoomItem(int count) {
        for (int i = 0; i < count; i++) {
            GameObject roomItem = GameObject.Instantiate(roomItemPrefab);
            roomItem.transform.SetParent(roomLayout.transform);
        }
        //解决房间过多而显示不出来
        int roomCount = GetComponentsInChildren<RoomItem>().Length;
        Vector2 size =roomLayout.GetComponent<RectTransform>().sizeDelta;
        roomLayout.GetComponent<RectTransform>().sizeDelta =
        new Vector2(size.x, roomCount * (roomItemPrefab.GetComponent<RectTransform>().sizeDelta.y+roomLayout.spacing));
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            LoadRoomItem(1);
        }
    }
}
