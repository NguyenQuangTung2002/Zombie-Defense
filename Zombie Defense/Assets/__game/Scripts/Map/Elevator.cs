using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Elevator otherElevator;

    public Animator animator;
    public bool isUnlock = true;
    public bool isUsing = false;
    public bool isAuto = false;
    public int useLimit = 3;
    public int numUse = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        animator.speed = 0.5f;
        isUnlock = true;
        animator.SetBool("IsUnlock", true);
        numUse = 0;
        useLimit = 3;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isUnlock && !isUsing && otherElevator.gameObject.activeInHierarchy && numUse <= useLimit)
        {
            StartCoroutine(Move());
            isUsing = true;
            otherElevator.isUsing = true;
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);

        MoveDown();
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "ElevatorDown")
            {
                yield return new WaitForSeconds(clip.length);
            }
        }
       
        otherElevator.MoveUp();
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "ElevatorUp")
            {
                yield return new WaitForSeconds(clip.length);
            }
        }
        
        Character.Instance.rb.isKinematic = false;
        Character.Instance.transform.parent = null;
        Character.Instance.transform.position = new Vector3(Character.Instance.transform.position.x, 0.4f,
            Character.Instance.transform.position.z);
        CharController.Instance.ChangeState(CharState.Normal);
        
        isAuto = true;
        MoveUp();
        yield return new WaitForSeconds(2f);

        isAuto = false;
        isUsing = false;
        otherElevator.isUsing = false;
        numUse++;
        
        if (numUse >= useLimit)
        {
            animator.SetBool("Unlock", false);
            otherElevator.animator.SetBool("Unlock", false);
        }
    }

    public void MoveDown()
    {
        animator.Play("ElevatorDown");

        if (!isAuto)
        {
            Character.Instance.rb.isKinematic = true;
            CharController.Instance.ChangeState(CharState.Waiting);
            Character.Instance.transform.parent = transform.GetChild(5);
        }

        //animator.SetBool("IsDefault", true);
    }

    public void MoveUp()
    {
        animator.Play("ElevatorUp");

        if (!isAuto)
        {
            Character.Instance.transform.parent = null;
            Character.Instance.transform.position = transform.GetChild(5).position;
            Character.Instance.transform.parent = transform.GetChild(5);
        }

        //animator.SetBool("IsDefault", true);
        
    }
}