using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class ReviveAct :FSMAction
{
    private readonly CharController characterCtrl;

    public ReviveAct(CharController characterController, FSMState owner) : base(owner)
    {
        characterCtrl= characterController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
  
    }
    
}