using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public AttackRadius attackRadius;
    public Canvas circle;
    public Image loadingCircle;
    public int damage;
    public TrapCtrl trapCtrl;
    
    [HideInInspector] public float timeToLoad;
    [HideInInspector] public float timeValue;
    [HideInInspector] public bool isRunningCou;
    
    private List<Damageable> targetToDamage;
    private Animator animator;

    void Awake()
    {
        attackRadius.AttackAllTarget += GetEnemies;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        timeValue = timeToLoad;
        isRunningCou = false;
    }

    public void GetEnemies(List<Damageable> target)
    {
        if (target != null && !isRunningCou && trapCtrl.gameObject.activeSelf)
        {
            targetToDamage = target;
            animator.SetBool("IsTrapUp",true);
            for (int i = 0; i < targetToDamage.Count; i++)
            {
                targetToDamage[i].GetTransform().GetComponent<Enemy>().Nav.isStopped = true;
                
            }
            
            StartCoroutine(Coutdown());
        }
        else
        {
            
            targetToDamage = null;
        }
        
    }

    public void Attack()
    {
        for (int i = 0; i < targetToDamage.Count; i++)
        {
            targetToDamage[i].TakeDamage(damage);
        }
    }
    
    IEnumerator Coutdown()
    {
        isRunningCou = true;
        circle.gameObject.SetActive(true);

        while (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            loadingCircle.fillAmount = timeValue / timeToLoad;
            yield return null;
        }
        
        timeValue = timeToLoad;
        circle.gameObject.SetActive(false);
        animator.SetBool("IsTrapDown",true);
        for (int i = 0; i < targetToDamage.Count; i++)
        {
            if (targetToDamage[i].GetTransform().gameObject.activeSelf)
                targetToDamage[i].GetTransform().GetComponent<Enemy>().Nav.isStopped = false;
        }

        yield return new WaitForSeconds(0.5f);
        isRunningCou = false;
        animator.SetBool("IsTrapDown",false);
        animator.SetBool("IsTrapUp",false);
    }
}
