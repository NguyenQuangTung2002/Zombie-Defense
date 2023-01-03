using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WorldLevelSystem : MonoBehaviour
{
    [SerializeField] private int worldLevelStart;
    [SerializeField] private int currenLevel;
    [SerializeField] private int worldLevelFinish;

    public bool isEndLevel = false;
    public int CurrentLevel
    {
        get => currenLevel;
        set => currenLevel = CurrentLevel;
    }
    void Start()
    {
        worldLevelStart = 0;
        worldLevelFinish = 2;
        currenLevel = 0;
        WorldController.Instance.OnWorldLevelFinishedLoading(this);
    }

    public void UpLevel()
    {
        currenLevel++;
        SceneData.Instance.SaveSceneData();
        if (currenLevel == worldLevelFinish)
        {
            isEndLevel = true;
        }
    }
}
