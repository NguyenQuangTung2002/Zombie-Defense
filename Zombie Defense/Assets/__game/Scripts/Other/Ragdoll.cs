using System;
using System.Collections;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public Collider mainCollider; 
    public Collider[] col;
    public Animator animator;
    public Rigidbody[] rb;

    public GameObject healthBar;
    
    private void Start()
    {
        isRagdoll(false);
    }

    public void isRagdoll(bool isragdoll)
    {
        if (isragdoll == false)
        {
            healthBar.SetActive(true);
            animator.enabled = true; 
            mainCollider.enabled = true;
            disableCollider();
            for (int i = 0; i < col.Length; i++)
            {
                Physics.IgnoreCollision(col[i], mainCollider);
            }
        }
        else
        {
            healthBar.SetActive(false);
            mainCollider.enabled = false;
            animator.enabled = false;
            for (int i = 0; i < col.Length; i++)
            {
                Physics.IgnoreCollision(mainCollider, col[i]);
            }
            OnCollider();
        }
    }
    void disableCollider()
    {
        for (int i = 0; i < col.Length; i++)
        {
            rb[i].useGravity= false;
            col[i].enabled = false;
            col[i].isTrigger = true;
            rb[i].isKinematic = true;
        }
    }
    
    void OnCollider()
    {
        for (int i = 0; i < col.Length; i++)
        {
            rb[i].useGravity= true;
            col[i].enabled = true;
            col[i].isTrigger = false;
            rb[i].isKinematic = false;
        }
    }
}
