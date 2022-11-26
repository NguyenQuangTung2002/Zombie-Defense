using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackRadius : MonoBehaviour
{
    public SphereCollider Collider;
    private List<Damageable> damageables = new List<Damageable>();
    public float attackDelay = 0.5f;
    public float timeLoadDelay = 0.5f;
    public delegate void AttackEvent(Damageable Target);
    public delegate void AttackAll(List<Damageable> Target);
    public AttackEvent OnAttack;
    public AttackAll AttackAllTarget;
    private Coroutine attackTarget;

    private void Awake()
    {
        Collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Get all damageable
     
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageables.Add(damageable);

            if (attackTarget == null)
            {
                attackTarget = StartCoroutine(AttackClosestDamageable());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Delete damageable out radius
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageables.Remove(damageable);
          
            if (damageables.Count == 0)
            {
                // Stop attack damageable out radius
                OnAttack?.Invoke(null);
                AttackAllTarget?.Invoke(null);
                StopCoroutine(attackTarget);
                attackTarget = null;
            }
        }
        
    }

    private IEnumerator AttackClosestDamageable()
    {
        yield return new WaitForSeconds(attackDelay);;

        Damageable closestDamageable = null;
        float closestDistance = float.MaxValue;

        while (damageables.Count > 0)
        {
            AttackAllTarget?.Invoke(damageables);
            
            //Get closest deamageable
            for (int i = 0; i < damageables.Count; i++)
            {
                Transform damageableTransform = damageables[i].GetTransform();
                float distance = Vector3.Distance(transform.position, damageableTransform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestDamageable = damageables[i];
                }
            }
            
            // Attack
            if (closestDamageable != null)
            {
                OnAttack?.Invoke(closestDamageable);
            }
            
            yield return new WaitForSeconds(timeLoadDelay);
            
            // Stop attack active-false damagaable
            if(!closestDamageable.GetTransform().gameObject.activeSelf)
            {
                OnAttack?.Invoke(null);
            }
            
            closestDamageable = null;
            closestDistance = float.MaxValue;
            
            damageables.RemoveAll(GetDisabledDamageables);
        }
        
        attackTarget = null;
    }

    private bool GetDisabledDamageables(Damageable Damageable)
    {
        return Damageable != null && !Damageable.GetTransform().gameObject.activeSelf;
    }
}