using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class DieAct :  FSMAction
{
    private readonly CharController characterCtrl;

    public DieAct(CharController characterController, FSMState owner) : base(owner)
    {
        characterCtrl= characterController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        CharController.Instance.ragdoll.isRagdoll(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        CharController.Instance.ragdoll.isRagdoll(false);
    }
}
