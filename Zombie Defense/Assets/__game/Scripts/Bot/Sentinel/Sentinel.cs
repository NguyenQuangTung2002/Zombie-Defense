using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sentinel : MonoBehaviour
{
    public AttackRadius attackRadius;
    public int damage = 3;

    public Damageable targetToDamage;
    private Transform defaultTransform;
    
    public Weapon weapon;

    void Awake()
    {
        attackRadius.OnAttack += Attack;
        weapon = GetComponentInChildren<Weapon>();
    }

    void Start()
    {
        GetComponentInChildren<AttackRadius>().timeLoadDelay = 0.1f;
        defaultTransform = transform;
    }

    private void Update()
    {
        Look();
    }

    public void Attack(Damageable target)
    {
        if (target != null)
        {
            targetToDamage = target;
            weapon.Attack(targetToDamage);
        }
        else
        {
            targetToDamage = null;
            transform.LookAt(defaultTransform.position);
        }
    }

    void Look()
    {
        if (targetToDamage != null)
        {
            Vector3 vectorTarget = (targetToDamage.GetTransform().position - transform.position).normalized;
            vectorTarget.y = transform.forward.y;
            
            transform.rotation =  Quaternion.LookRotation(Vector3.RotateTowards(
                transform.forward, vectorTarget.normalized, 10f * Time.deltaTime, 0f));
        }
        else
        {
            transform.LookAt(defaultTransform.position);
        }
    }
}