using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int number;
    [SerializeField] private float timeToStart;
    [SerializeField] private float timeToWait;

    public int numberEnemy;

    public void Spawm()
    {
        number = Random.Range(5, 7);
        numberEnemy = number;
        timeToStart = Random.Range(2, 4);
        timeToWait = Random.Range(0f, 1f);

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(timeToStart);
        for (int i = 0; i < number; i++)
        {
            Enemy enemy = ObjectToPooling.Instance.GetPoolingEnemy();
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;
            enemy.Init();
            enemy.gameObject.SetActive(true);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}