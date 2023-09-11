using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VirtueSky.Events;

public class PopupInGame : Popup
{
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textPoint;
    public TextMeshProUGUI textTarget;
    public DynamicJoystick DynamicJoystick;

    public EventNoParam eventRePlay;
    public EventNoParam eventReturnHome;

    protected override void BeforeShow()
    {
        textLevel.text = "Level " + Data.CurrentLevel;
        //textTarget.text = "Target " + GameManager.Instance.LevelController.CurrentLevel.pointTarget + " Point";
    }

    private void Update()
    {
       // textPoint.text = "Point: " + GameManager.Instance.Point;
    }


    public void OnClickReplay()
    {
        eventRePlay.Raise();
    }
    public void OnClickBackHome()
    {
        eventReturnHome.Raise();
    }
}
