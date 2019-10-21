using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text username;
    public Text totalCount;
    public Text winCount;
    public Button joinButton;
    // Start is called before the first frame update
    void Start()
    {
        if (joinButton != null) {
            joinButton.onClick.AddListener(OnJoinClick);
        }
    }
    public void SetRoomInfo( string username, int totalCount, int winCount) {

        this.username.text = username;
        this.totalCount.text = "TotalMatch\n"+totalCount;
        this.winCount.text = "WinMatch\n"+ winCount;
    }
    //public void SetRoomInfo(string username, string totalCount, string winCount)
    //{

    //    this.username.text = username;
    //    this.totalCount.text = "TotalMatch\n" + totalCount;
    //    this.winCount.text = "WinMatch\n" + winCount;
    //}

    // Update is called once per frame
    private void OnJoinClick() {

    }
    public void DestroySelf() {
        GameObject.Destroy(this.gameObject);
    }
}
