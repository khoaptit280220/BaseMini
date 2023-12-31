using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using VirtueSky.Events;

public class GameManager : MonoBehaviour
{
    public LevelController LevelController;
    public GameState GameState;
    [HideInInspector] public int Point = 0;

    public EventShowPopup eventShowPopup;
    public EventHidePopup eventHidePopup;
    public EventNoParam eventHideAll;

    void Start()
    {
        DontDestroyOnLoad(this);
        ReturnHome();
    }

    public void PrepareLevel()
    {
        GameState = GameState.PrepareGame;
        Point = 0;
        LevelController.PrepareLevel();
        eventShowPopup.Raise(typeof(PopupHome));
    }

    public void ReturnHome()
    {
        PrepareLevel();
        eventHideAll.Raise();
        eventShowPopup.Raise(typeof(PopupHome));
    }

    public void ReplayGame()
    {
        PrepareLevel();
        StartGame();
    }

    public void StartGame()
    {
        GameState = GameState.PlayingGame;
        LevelController.CurrentLevel.gameObject.SetActive(true);

        eventHideAll.Raise();

        eventShowPopup.Raise(typeof(PopupInGame));
    }

    public void OnWinGame(float delayPopupShowTime = 1f)
    {
        if (GameState == GameState.LoseGame || GameState == GameState.WinGame) return;
        GameState = GameState.WinGame;
        Data.CurrentLevel++;

        DOTween.Sequence().AppendInterval(delayPopupShowTime).AppendCallback(() =>
        {
            eventHideAll.Raise();

            eventShowPopup.Raise(typeof(PopupWin));
        });
    }

    public void OnLoseGame(float delayPopupShowTime = 1f)
    {
        if (GameState == GameState.LoseGame || GameState == GameState.WinGame) return;
        GameState = GameState.LoseGame;

        DOTween.Sequence().AppendInterval(delayPopupShowTime).AppendCallback(() =>
        {
            eventHideAll.Raise();

            eventShowPopup.Raise(typeof(PopupLose));
        });
    }
}

public enum GameState
{
    PrepareGame,
    PlayingGame,
    LoseGame,
    WinGame,
}