using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SubGun : RangedWeapon
{
    private Drone owner;
    public void Awake()
    {
        owner = GetComponentInParent<Drone>();
    }
    
    protected override void Start()
    { 
        owner.attackRadius.attackDelay =0.5f;
        owner.attackRadius.timeLoadDelay =0.1f;
        damage = 5;
        bulletSpeed = 20;
        amountBulletTurn = 1;
    }
    
    public override void Attack(Damageable targetToDamage)
    {
        Vector3 vectorVel = targetToDamage.GetTransform().position - transform.position;
        vectorVel.y += 1;
        
        turn = LoadBullet();

        AttackMethod(vectorVel);
    }

    protected override void AttackMethod(Vector3 vectorVel)
    {
        foreach (var bullet in turn)
        {
            if (bullet != null)
            {
                bullet.damage = damage;
                bullet.Move(bulletSpeed, vectorVel.normalized);
            }
        }
    }
}
