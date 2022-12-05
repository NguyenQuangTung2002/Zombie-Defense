using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    protected List<Bullet> turn;
    public float bulletSpeed;
    public int damage;
    protected int amountBulletTurn;

    [SerializeField]private Transform bulletSpawner;
    
    protected virtual void Start() { }

    public override void Attack(Damageable targetToDamage)
    {
        Vector3 vectorVel = targetToDamage.GetTransform().position - transform.position;
        vectorVel.y = 0;
        
        turn = LoadBullet();

        AttackMethod(vectorVel);
    }
    
    protected List<Bullet> LoadBullet()
    {

        List<Bullet> turnShoot = new List<Bullet>();
        
        for (int i = 0; i < amountBulletTurn; i++)
        {
            Bullet bullet = ObjectToPooling.Instance.GetPooledBullet();
            if (bullet != null)
            {
                bullet.transform.position = bulletSpawner.transform.position;
                bullet.transform.rotation = bulletSpawner.transform.rotation;
                bullet.damage = damage;
                bullet.gameObject.SetActive(true);
            }
            turnShoot.Add(bullet);
        }

        return turnShoot;
    }
    
    protected virtual void AttackMethod(Vector3 vectorVel)
    {
        Debug.Log("Method virtual");
    }
    
}
