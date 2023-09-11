using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Level CurrentLevel;
    public int MaxLevel;
    public int StartLoopLevel = 1;
    
    public void PrepareLevel()
    {
        GenerateLevel(Data.CurrentLevel);
    }

    public void GenerateLevel(int indexLevel)
    {
        if (CurrentLevel != null)
        {
            Destroy(CurrentLevel.gameObject);
        }
        if (indexLevel > MaxLevel)
        {
            indexLevel = (indexLevel-StartLoopLevel) % (MaxLevel - StartLoopLevel+1) + StartLoopLevel;
        }
        else
        {
            indexLevel = (indexLevel-1) % MaxLevel + 1;
        }

        Level level = GetLevelByIndex(indexLevel);
        CurrentLevel = Instantiate(level);
        CurrentLevel.gameObject.SetActive(false);
    }
    public Level GetLevelByIndex(int indexLevel)
    {
        GameObject levelGO;

        levelGO = Resources.Load($"Level {indexLevel}") as GameObject;
            
        return levelGO.GetComponent<Level>();
    }
}
