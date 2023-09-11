using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupHome : Popup
{
    public void OnClickStart()
    {
        GameManager.Instance.StartGame();
        Debug.Log("Start");
    }
}
