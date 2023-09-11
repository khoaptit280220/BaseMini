using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWin : Popup
{
    public void OnClicKContinue()
    {
        GameManager.Instance.PrepareLevel();
        GameManager.Instance.StartGame();
    }
}
