using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class ContinueBattleAct : FSMAction
{
    private readonly WorldController worldCtrl;

    public ContinueBattleAct(WorldController worldController, FSMState owner) : base(owner)
    {
        worldCtrl= worldController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        CharController.Instance.ChangeState(CharState.Revive);
    }
}
