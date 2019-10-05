using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button closeButton;

    public override void OnEnter()
    {
        base.OnEnter();
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
        transform.localPosition = new Vector3(0, 1000, 0);
        transform.DOLocalMove(Vector3.zero, 0.5f);

        closeButton = transform.Find("Close").GetComponent<Button>();
        closeButton.onClick.AddListener(OnCloseClick);

    }
    private void OnCloseClick() {
        transform.DOScale(0, 0.5f);
        Tweener tweener = transform.DOLocalMove(new Vector3(0,1000,0),0.5f);
        tweener.OnComplete(() => uiMng.PopPanel());
    }
}