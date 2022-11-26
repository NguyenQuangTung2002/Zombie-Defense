using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class WaitAct : FSMAction
{
    private readonly CharController characterCtrl;

    public WaitAct(CharController characterController, FSMState owner) : base(owner)
    {
        characterCtrl= characterController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Character.Instance.Move(Vector3.zero);
        Character.Instance.Look( Character.Instance.transform.forward);
        Character.Instance.animator.SetFloat("Velocity",0);
    }
}