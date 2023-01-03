using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    protected virtual void Start() { }

    public override void Attack(Damageable targetToDamage)
    {
        AttackMethod();
    }
    protected virtual void AttackMethod()
    {
        Debug.Log("Method virtual");
    }
}
