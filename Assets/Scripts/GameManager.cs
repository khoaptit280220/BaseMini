using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public LevelController LevelController;
    public GameState GameState;
    [HideInInspector] public int Point = 0;
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
        PopupController.Instance.Show<PopupHome>();
    }
    public void ReturnHome()
    {
        PrepareLevel();

        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupHome>();
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
        PopupController.Instance.HideAll();
        PopupController.Instance.Hide<PopupHome>();
        PopupController.Instance.Show<PopupInGame>();
    }

    public void OnWinGame(float delayPopupShowTime = 1f)
    {
        if (GameState == GameState.LoseGame || GameState == GameState.WinGame) return;
        GameState = GameState.WinGame;
        Data.CurrentLevel++;

        DOTween.Sequence().AppendInterval(delayPopupShowTime).AppendCallback(() =>
        {
            PopupController.Instance.HideAll();
            PopupController.Instance.Show<PopupWin>();
        });
    }

    public void OnLoseGame(float delayPopupShowTime = 1f)
    {
        if (GameState == GameState.LoseGame || GameState == GameState.WinGame) return;
        GameState = GameState.LoseGame;

        DOTween.Sequence().AppendInterval(delayPopupShowTime).AppendCallback(() =>
        {
            PopupController.Instance.HideAll();
            PopupController.Instance.Show<PopupLose>();
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
