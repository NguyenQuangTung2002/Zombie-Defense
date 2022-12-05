using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class M4A1 : RangedWeapon
{
    protected override void Start()
    {
        CharController.Instance.attackRadius.attackDelay =0.5f;
        CharController.Instance.attackRadius.timeLoadDelay =0.1f;
        damage = 5;
        bulletSpeed = 20;
        amountBulletTurn = 1;
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
