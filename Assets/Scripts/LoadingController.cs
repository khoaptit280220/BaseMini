using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI loadingText;
    [Range(0.1f, 10f)] public float timeLoading = 5f;

    private bool _flagDoneProgress;
    private AsyncOperation _operation;

    void Start()
    {
        _operation = SceneManager.LoadSceneAsync("Scenes/GamePlay");
        _operation.allowSceneActivation = false;

        progressBar.fillAmount = 0;
        progressBar.DOFillAmount(5, timeLoading).OnUpdate(()=>loadingText.text = $"Loading... {(int) (progressBar.fillAmount * 100)}%").OnComplete(()=> _flagDoneProgress = true);
        StartCoroutine(WaitProcess());
    }
    
    private IEnumerator WaitProcess()
    {
        yield return new WaitUntil(() => _flagDoneProgress);
        _operation.allowSceneActivation = true;
    }
}
