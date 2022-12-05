using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class StartBattleAct : FSMAction
{
    private readonly WorldController worldCtrl;

    public StartBattleAct(WorldController worldController, FSMState owner) : base(owner)
    {
        worldCtrl= worldController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        CharController.Instance.ChangeState(CharState.Normal);
        if (GameManager.Instance != null)
        {
            /*GameManager.Instance.UiController.UiInGame.ShowStartBattleUI();*/
        }
        EnemyManager.Instance.SpawnEnemy();
        foreach (var elevantor in worldCtrl.elevantors)
        {
            if (elevantor != null)
            {
                elevantor.Init();
            }
        }
        Debug.Log("StartGame");
    }
}
