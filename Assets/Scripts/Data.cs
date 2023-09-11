using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static string CURRENT_LEVEL = "CURRENT_LEVEL";

    public static int CurrentLevel
    {
        get => PlayerPrefs.GetInt(CURRENT_LEVEL, 1);
        set => PlayerPrefs.SetInt(CURRENT_LEVEL, value);
    }
}
