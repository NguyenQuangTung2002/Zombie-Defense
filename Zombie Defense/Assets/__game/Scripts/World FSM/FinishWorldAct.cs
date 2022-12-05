using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class FinishWorldAct : FSMAction
{
    private readonly WorldController worldCtrl;

    public FinishWorldAct(WorldController worldController, FSMState owner) : base(owner)
    {
        worldCtrl= worldController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        CharController.Instance.ChangeState(CharState.Normal);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UiController.UiInGame.ShowFinishWorldUI();
        }
        Debug.Log("Finish World");
    }

    public override void OnExit()
    {
        base.OnExit();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UiController.UiInGame.HideFinishWorldUI();
        }
    }
}
