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
    private void Start()
    {
        localPlayerUsername = transform.Find("Player1/UserName").GetComponent<Text>();
        localPlayerTotalcount = transform.Find("Player1/TotalCount").GetComponent<Text>();
        localPlayerWinCount = transform.Find("Player1/WinCount").GetComponent<Text>();

        enemyPlayerUsername = transform.Find("Player2/UserName").GetComponent<Text>();
        enemyPlayerTotalcount = transform.Find("Player2/TotalCount").GetComponent<Text>();
        enemyPlayerTotalcount = transform.Find("Player2/WinCount").GetComponent<Text>();

        Player1 = transform.Find("Player1");
        Player2 = transform.Find("Player2");
        StartButton = transform.Find("Start");
        ExitButton = transform.Find("Exit");

        transform.Find("Start").GetComponent<Button>().onClick.AddListener(OnStartClick);
        transform.Find("Exit").GetComponent<Button>().onClick.AddListener(OnExitClick);
        PlayAnim();
    }
    public override void OnEnter()
    {
        if (Player1 != null)
            PlayAnim();
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
    private void SetLocalPlayerRes(string username, string totalCount, string winCount) {
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
    private void ClearEnemyPlayer(string username, string totalCount, string winCount)
    {
        enemyPlayerUsername.text = "";
        enemyPlayerTotalcount.text = "";
        enemyPlayerWincount.text = "";
    }


    private void OnStartClick() {

    }
    private void OnExitClick() {

    }
    private void PlayAnim() {
        gameObject.SetActive(true);
        Player1.localPosition = new Vector3(-1000, 0, 0);
        Player1.DOLocalMoveX(481, 0.5f);

        Player2.localPosition = new Vector3(1000, 0, 0);
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



