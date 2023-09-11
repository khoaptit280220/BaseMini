using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    public float boundZ = 45;
    public float boundX = 42;
    private void RePos()
    {
        gameObject.SetActive(false);
        float x = Random.Range(-boundX, boundX);
        float z = Random.Range(-boundZ, boundZ);
        transform.position = new Vector3(x, transform.position.y, z);
        DOTween.Sequence().SetDelay(1).OnComplete(() =>
        {
            gameObject.SetActive(true);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Point++;
            if (GameManager.Instance.Point == GameManager.Instance.LevelController.CurrentLevel.pointTarget)
            {
                GameManager.Instance.OnWinGame(1);
            }
            RePos();
            other.GetComponent<PlayerController>().SetColor(GetComponent<MeshRenderer>().material.color);
        }
    }
}
