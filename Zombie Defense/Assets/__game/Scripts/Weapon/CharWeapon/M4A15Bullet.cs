using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A15Bullet : RangedWeapon
{
    protected override void Start()
    {
        CharController.Instance.attackRadius.attackDelay =0.5f;
        CharController.Instance.attackRadius.timeLoadDelay =1f;
        damage = 100;
        bulletSpeed = 20;
        amountBulletTurn = 5;
    }
    
    protected override void AttackMethod(Vector3 vectorVel)
    {
        var average = (amountBulletTurn-1) /2;
        for (int i = 0; i < turn.Count; i++)
        {
            var vector = Quaternion.AngleAxis(15 * (i - average),  Vector3.up)*vectorVel;
            turn[i].Move(bulletSpeed,vector);
            turn[i].damage = damage;
        }
    }
}
