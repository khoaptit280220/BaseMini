using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtueSky.Events;

public class PopupLose : Popup
{
    public EventNoParam eventReplay;
    
    public void OnClickReplay()
    {
        eventReplay.Raise();
    }
}
