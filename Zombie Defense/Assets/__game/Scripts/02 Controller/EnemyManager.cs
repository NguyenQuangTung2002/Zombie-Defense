using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance; 
    
    public List<GameObject> doors;
    public List<SpawnerEnemy> spawners;
    public int numDeadEnemy = 0;
    public int numEnemy = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < doors.Count; i++)
        {
            spawners.Add( doors[i].GetComponentInChildren<SpawnerEnemy>());
        }
    }

    public void SpawnEnemy()
    {
        int count = 0;
        for (int i = 0; i < spawners.Count; i++)
        {
            if (spawners[i].gameObject.activeInHierarchy)
            {
                spawners[i].Spawm();
                count += spawners[i].numberEnemy;
            }
            i +=(int)(Random.Range(0, 4) / 4);
        }

        numEnemy = count;
    }

    private void Update()
    {
        if (numDeadEnemy == numEnemy && numDeadEnemy != 0)
        {
            WorldController.Instance.LoadWorldLevel();
            numDeadEnemy = 0;
            numEnemy = 0;
        }
    }
}