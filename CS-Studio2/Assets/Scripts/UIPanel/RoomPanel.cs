using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RoomPanel : BasePanel
{
   
    private Text localPlayerUsername;
    private Text localPlayerTotalcount;
    private Text localPlayerWinCount;

    private Text enemyPlayerUsername;
    private Text enemyPlayerTotalcount;
    private Text enemyPlayerWincount;

    private Transform Player1;
    private Transform Player2;
    private Transform StartButton;
    private Transform ExitButton;

    private CreateRoomRequest crRequest;
    private UserData ud = null;
    private void Start()
    {
        localPlayerUsername = transform.Find("Player1/UserName").GetComponent<Text>();
        localPlayerTotalcount = transform.Find("Player1/TotalCount").GetComponent<Text>();
        localPlayerWinCount = transform.Find("Player1/WinCount").GetComponent<Text>();

        enemyPlayerUsername = transform.Find("Player2/UserName").GetComponent<Text>();
        enemyPlayerTotalcount = transform.Find("Player2/TotalCount").GetComponent<Text>();
        enemyPlayerWincount = transform.Find("Player2/WinCount").GetComponent<Text>();

        Player1 = transform.Find("Player1");
        Player2 = transform.Find("Player2");
        StartButton = transform.Find("Start");
        ExitButton = transform.Find("Exit");

        crRequest = GetComponent<CreateRoomRequest>();

        transform.Find("Start").GetComponent<Button>().onClick.AddListener(OnStartClick);
        transform.Find("Exit").GetComponent<Button>().onClick.AddListener(OnExitClick);
        PlayAnim();
    }
    public override void OnEnter()
    {
        if (Player1 != null)
            PlayAnim();
        if (crRequest == null)
            crRequest = GetComponent<CreateRoomRequest>();
        crRequest.SendRequest();
    }
    public override void OnExit()
    {
        ExitAnim();
    }
    public override void OnPause()
    {
        ExitAnim();
    }
    public override void OnResume()
    {
        PlayAnim();

    }
    private void Update()
    {
        if (ud != null) {
            SetLocalPlayerRes(ud.Username, ud.TotalCount.ToString(), ud.WinCount.ToString());
            ClearEnemyPlayer();
            ud = null;
      }
    }
    public void SetLocalPlayerResSync() {
        ud = facade.GetUserData();

    }
    public  void SetLocalPlayerRes(string username, string totalCount, string winCount) {
        localPlayerUsername.text = username;
        localPlayerTotalcount.text = "TotalMatch"+totalCount;
        localPlayerWinCount.text = "WinMatch"+winCount;
    }
    private void SetenemyPlayerRes(string username, string totalCount, string winCount)
    {
        enemyPlayerUsername.text = username;
        enemyPlayerTotalcount.text = "TotalMatch" + totalCount;
        enemyPlayerWincount.text = "WinMatch" + winCount;
    }
    public  void ClearEnemyPlayer()
    {
        enemyPlayerUsername.text = "";
        enemyPlayerTotalcount.text = "Waiting for player...";
        enemyPlayerWincount.text = "";
    }


    private void OnStartClick() {

    }
    private void OnExitClick() {

    }
    private void PlayAnim() {
        gameObject.SetActive(true);
        Player1.localPosition = new Vector3(1000, 0, 0);
        Player1.DOLocalMoveX(481, 0.5f);

        Player2.localPosition = new Vector3(-1000, 0, 0);
        Player2.DOLocalMoveX(-481, 0.5f);

        StartButton.localScale =  Vector3.zero;
        StartButton.DOScale(1, 0.5f);
        ExitButton.localScale = Vector3.zero;
        ExitButton.DOScale(1, 0.5f);
    }
    private void ExitAnim() {
        
        Player1.DOLocalMoveX(-1000, 0.5f);
        Player2.DOLocalMoveX(1000, 0.5f);
     
        StartButton.DOScale(0, 0.5f);
        ExitButton.DOScale(0, 0.5f).OnComplete(() => gameObject.SetActive(false));

    }
}



