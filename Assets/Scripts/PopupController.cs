using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public Transform CanvasTransform;
    public CanvasScaler CanvasScaler;
    public float DurationPopup = 0.2f;
    public List<Popup> Popups;

    private Dictionary<Type, Popup> dictionary = new Dictionary<Type, Popup>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Initialize();
        // CanvasScaler.matchWidthOrHeight = Camera.main.aspect > .7f ? 1 : 0;
    }

    public void Initialize()
    {
        int index = 0;
        Popups.ForEach(popup =>
        {
            Popup popupInstance = Instantiate(popup, CanvasTransform);
            popupInstance.gameObject.SetActive(false);
            popupInstance.Canvas.sortingOrder = index++;
            popupInstance.CanvasGroup.alpha = 0;
            popupInstance.CanvasGroup.interactable = false;
            dictionary.Add(popupInstance.GetType(), popupInstance);
            
        });
    }

    public void Show(Type T)
    {
        if (dictionary.TryGetValue(T, out Popup popup))
        {
            if (!popup.isActiveAndEnabled)
            {
                popup.Show();
            }
        }
    }

    public void Hide(Type T)
    {
        if (dictionary.TryGetValue((T), out Popup popup))
        {
            if (popup.isActiveAndEnabled)
            {
                popup.Hide();
            }
        }
    }
    // public void Show<T>()
    // {
    //     if (dictionary.TryGetValue(typeof(T), out Popup popup))
    //     {
    //         if (!popup.isActiveAndEnabled)
    //         {
    //             popup.Show();
    //         }
    //     }
    // }
    //
    // public void Hide<T>()
    // {
    //     if (dictionary.TryGetValue(typeof(T), out Popup popup))
    //     {
    //         if (popup.isActiveAndEnabled)
    //         {
    //             popup.Hide();
    //         }
    //     }
    // }

    public void HideAll()
    {
        foreach (Popup item in dictionary.Values)
        {
            if (item.isActiveAndEnabled)
            {
                item.Hide();
            }
        }
    }

    public Popup Get(Type T)
    {
        if (dictionary.TryGetValue((T), out Popup popup))
        {
            return popup;
        }
        return null;
    }
}
