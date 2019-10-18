using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListPanel : BasePanel

{
    private RectTransform matchData;
    private RectTransform roomList;
    private void Start()
    {
        matchData = transform.Find("MatchData").GetComponent<RectTransform>();
        roomList = transform.Find("RoomList").GetComponent<RectTransform>();
        transform.Find("RoomList/Close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
    }
    public override void OnEnter()
    {
        gameObject.SetActive(true);
        
    }
    public override void OnExit()
    {
       
    }
    private void OnCloseClick() {

        PlayClickSound();
        uiMng.PopPanel();
        gameObject.SetActive(false);
    }
}
