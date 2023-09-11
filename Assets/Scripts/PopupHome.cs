using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtueSky.Events;

public class PopupHome : Popup
{
    public EventNoParam eventStartGame;
    public void OnClickStart()
    {
        eventStartGame.Raise();
    }
}
