using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtueSky.Events;

public class PopupWin : Popup
{
    public EventNoParam eventPrepareLevel;
    public EventNoParam eventStartGame;
    
    public void OnClicKContinue()
    {
       eventPrepareLevel.Raise();
       eventStartGame.Raise();
    }
}
