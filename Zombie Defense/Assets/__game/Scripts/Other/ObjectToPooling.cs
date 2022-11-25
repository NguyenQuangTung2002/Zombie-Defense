using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToPooling : MonoBehaviour
{
    public static ObjectToPooling Instance;
    public List<Bullet> bulletsToPooling;
    public Bullet bullet;
    private int numBullet;

    public List<Enemy> enemyToPooling;
    public Enemy enemy;
    private int numEnemy;
    private void Awake()
    {
        Instance = this;
        
        // Instantiate Bullet
        numBullet = 100;
        bulletsToPooling = new List<Bullet>();
        Bullet tmp;
        for(int i = 0; i < numBullet; i++)
        {
            tmp = Instantiate(bullet);
            tmp.gameObject.SetActive(false);
            bulletsToPooling.Add(tmp);
        }
        
        //Instantiate Enemy
        numEnemy = 100;
        enemyToPooling = new List<Enemy>();
        Enemy tmp1;
        for (int i = 0; i < numEnemy; i++)
        {
            tmp1 = Instantiate(enemy);
            tmp1.gameObject.SetActive(false);
            enemyToPooling.Add(tmp1);
        }
        
    }
    
    public Bullet GetPooledBullet()
    {
        for(int i = 0; i < numBullet; i++)
        {
            if(!bulletsToPooling[i].gameObject.activeInHierarchy)
            {
                return bulletsToPooling[i];
            }
        }
        return null;
    }

    public Enemy GetPoolingEnemy()
    {
        for (int i = 0; i < numEnemy; i++)
        {
            if (!enemyToPooling[i].gameObject.activeInHierarchy)
            {
                return enemyToPooling[i];
            }
        }

        return null;
    }
    
    
}
