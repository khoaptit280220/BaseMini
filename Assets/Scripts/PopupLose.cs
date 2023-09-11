using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupLose : Popup
{
    public void OnClickReplay()
    {
        GameManager.Instance.ReplayGame();
    }
}
