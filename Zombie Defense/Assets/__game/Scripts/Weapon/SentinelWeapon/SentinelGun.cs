using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelGun : RangedWeapon
{
    protected override void Start()
    {
        damage = 5;
        bulletSpeed = 20;
        amountBulletTurn = 1;
        
        GetComponentInParent<Sentinel>().attackRadius.timeLoadDelay =0.3f;
        GetComponentInParent<Sentinel>().damage = damage;
    }

    protected override void AttackMethod(Vector3 vectorVel)
    {
        vectorVel.y -=1f;
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
