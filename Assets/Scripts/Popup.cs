using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public class Popup : MonoBehaviour
{
    public CanvasGroup CanvasGroup { get; set; }
    public Canvas Canvas { get; set; }


    private void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        Canvas = GetComponent<Canvas>();
    }

    public void Show()
    {
        BeforeShow();
        gameObject.SetActive(true);
        CanvasGroup.DOFade(1, PopupController.Instance.DurationPopup).OnComplete(() =>
        {
            CanvasGroup.interactable = true;
            AfterShown();
        });
    }

    public void Hide()
    {

        BeforeHide();
        CanvasGroup.interactable = false;
        gameObject.SetActive(false);
        AfterHidden();

    }
    protected virtual void AfterInstantiate() { }
    protected virtual void BeforeShow() { }
    protected virtual void AfterShown() { }
    protected virtual void BeforeHide() { }
    protected virtual void AfterHidden() { }
    
}
